using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Core;

using Epiworx.Data;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index(
            int? userId,
            string userName)
        {
            var model = new UserListModel();
            var criteria =
                new UserDataCriteria
                    {
                        UserId = userId,
                        Name = userName
                    };
            var users = UserRepository.UserFetchInfoList(criteria);

            model.Users = users;

            var projects = ProjectRepository.ProjectFetchInfoList(
                new ProjectDataCriteria
                    {
                        IsActive = true,
                        IsArchived = false
                    });

            var stories = StoryRepository.StoryFetchInfoList(projects.ToArray(), false);

            model.Stories = stories;

            var timelines = TimelineRepository.TimelineFetchInfoList(
                users.Select(row => row.UserId).Distinct().ToArray(), SourceType.User);

            model.Timelines = timelines;

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var model = new UserFormModel();
            var user = UserRepository.UserFetch(id);
            var startDate = DateTime.Now.AddDays(-48).ToStartOfWeek().Date;
            var endDate = DateTime.Now.ToEndOfWeek().Date;
            var hours = HourRepository.HourFetchInfoList(user, startDate, endDate);

            model.User = user;
            model.ProjectListModel =
                new ProjectListModel
                    {
                        Projects = ProjectRepository.ProjectFetchInfoList(user)
                    };
            model.TimelineListModel =
                new TimelineListModel
                    {
                        Timelines = TimelineRepository.TimelineFetchInfoList(user),
                        SourceId = model.User.SourceId,
                        SourceTypeId = (int)model.User.SourceType,
                        IsEditable = false
                    };
            model.CurrentWeekHourSummaryByDateListModel =
                new HourSummaryByDateListModel
                {
                    User = user,
                    Hours = this.FetchHoursForWeek(
                        DateTime.Now.ToStartOfWeek(),
                        hours)
                };
            model.TrailingWeeksHourSummaryByDateListModel =
                new HourSummaryByDateListModel
                {
                    User = user,
                    Hours = this.FetchHoursForTrailingWeeks(
                        startDate,
                        endDate,
                        hours)
                };
            model.Stories = StoryRepository.StoryFetchInfoList(model.User, false);

            var weeks = WeekRepository.WeekFetchInfoList(
                 DateTime.Now.Year);
            var currentWeek = weeks.First(row => DateTime.Now.Date >= row.StartDate && DateTime.Now.Date <= row.EndDate);
            var currentPeriodStartDate = weeks.Where(row => row.Period == currentWeek.Period).Min(row => row.StartDate);
            var currentPeriodEndDate = weeks.Where(row => row.Period == currentWeek.Period).Max(row => row.EndDate);

            hours = HourRepository.HourFetchInfoList(
                user, weeks.Min(row => row.StartDate), weeks.Max(row => row.EndDate));
            var hourSummaries = new List<HourSummary>();

            hourSummaries.Add(new HourSummary { Name = "Week", Value = (double)hours.Where(row => row.Date >= currentWeek.StartDate.Date && row.Date <= currentWeek.EndDate.Date).Sum(row => row.Duration), NormalValue = 25 });
            hourSummaries.Add(new HourSummary { Name = "Period", Value = (double)hours.Where(row => row.Date >= currentPeriodStartDate.Date && row.Date <= currentPeriodEndDate.Date).Sum(row => row.Duration), NormalValue = 100 });
            hourSummaries.Add(new HourSummary { Name = "Year", Value = (double)hours.Sum(row => row.Duration), NormalValue = 1250 });

            model.HourSummaryListModel =
                new HourSummaryListModel
                {
                    User = user,
                    Hours = hourSummaries
                };

            return this.View(model);
        }

        private IEnumerable<HourSummaryByDate> FetchHoursForWeek(
            DateTime startDate, IEnumerable<HourInfo> hours)
        {
            var result = new List<HourSummaryByDate>();

            var currentDate = startDate;

            while (currentDate <= startDate.ToEndOfWeek())
            {
                result.Add(
                    new HourSummaryByDate
                    {
                        StartDate = currentDate.Date,
                        EndDate = currentDate.Date,
                        Duration = hours.Where(hour => hour.Date.Date == currentDate.Date).Sum(hour => hour.Duration)
                    });
                currentDate = currentDate.AddDays(1);
            }

            return result;
        }

        private IEnumerable<HourSummaryByDate> FetchHoursForTrailingWeeks(
            DateTime startDate, DateTime endDate, IEnumerable<HourInfo> hours)
        {
            var result = new List<HourSummaryByDate>();

            var currentDate = endDate;

            while (currentDate >= startDate)
            {
                result.Add(
                      new HourSummaryByDate
                      {
                          StartDate = currentDate.AddDays(-6).Date,
                          EndDate = currentDate.Date,
                          Duration = hours.Where(hour => hour.Date.Date >= currentDate.AddDays(-6).Date && hour.Date.Date <= currentDate.Date).Sum(hour => hour.Duration)
                      });
                currentDate = currentDate.AddDays(-7);
            }

            return result;
        }

        public ActionResult Create()
        {
            var model = new UserFormModel();

            return this.View(model);
        }

        public ActionResult Create(UserFormModel model)
        {
            return this.RedirectToAction("Details");
        }
    }
}
