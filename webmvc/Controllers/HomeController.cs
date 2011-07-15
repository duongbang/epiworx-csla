using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new HomeIndexModel();
            var user = UserRepository.UserFetch();

            model.User = user;
            model.StartDate = DateTime.Now.AddDays(-48).ToStartOfWeek(Settings.StartDayOfWeek).Date;
            model.EndDate = DateTime.Now.ToStartOfWeek(Settings.StartDayOfWeek).Date.AddDays(6);
            model.Hours = HourRepository.HourFetchInfoList(user, model.StartDate, model.EndDate);
            model.ProjectListModel =
                new ProjectListModel
                    {
                        Projects = ProjectRepository.ProjectFetchInfoList()
                    };
            model.FeedListModel =
                new FeedListModel
                    {
                        Feeds = FeedRepository.FeedFetchInfoList(20)
                    };
            model.TimelineListModel =
                new TimelineListModel
                    {
                        Timelines = TimelineRepository.TimelineFetchInfoList(model.User),
                        SourceId = model.User.SourceId,
                        SourceTypeId = (int)model.User.SourceType
                    };
            model.CurrentWeekHourSummaryByDateListModel =
                new HourSummaryByDateListModel
                    {
                        User = user,
                        Hours = this.FetchHoursForWeek(
                            DateTime.Now.ToStartOfWeek(Settings.StartDayOfWeek),
                            model.Hours)
                    };
            model.TrailingWeeksHourSummaryByDateListModel =
                new HourSummaryByDateListModel
                    {
                        User = user,
                        Hours = this.FetchHoursForTrailingWeeks(
                            model.StartDate,
                            model.EndDate,
                            model.Hours)
                    };


            var weeks = WeekCollection.GetWeeks(DateTime.Now.Year);

            var hours = HourRepository.HourFetchInfoList(
                user, weeks.Min(row => row.StartDate), weeks.Max(row => row.EndDate));
            var hourSummaries = new List<HourSummary>();

            hourSummaries.Add(
                new HourSummary
                    {
                        Name = "Week",
                        Value = (double)hours.Where(row => row.Date >= weeks.StartDate.Date && row.Date <= weeks.StartDate.AddDays(6)).Sum(row => row.Duration),
                        NormalValue = 25
                    });
            hourSummaries.Add(
                new HourSummary
                    {
                        Name = "Year",
                        Value = (double)hours.Sum(row => row.Duration),
                        NormalValue = 1250
                    });

            model.HourSummaryListModel =
                new HourSummaryListModel
                    {
                        User = user,
                        Hours = hourSummaries
                    };

            return View(model);
        }

        private IEnumerable<HourSummaryByDate> FetchHoursForWeek(
            DateTime startDate, IEnumerable<HourInfo> hours)
        {
            var result = new List<HourSummaryByDate>();

            var currentDate = startDate;

            while (currentDate <= startDate.AddDays(6))
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

            return result.OrderBy(row => row.StartDate);
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

            return result.OrderByDescending(row => row.StartDate);
        }
    }
}
