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
            model.StartDate = DateTime.Now.AddDays(-48).ToStartOfWeek().Date;
            model.EndDate = DateTime.Now.ToEndOfWeek().Date;
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
                            DateTime.Now.ToStartOfWeek(),
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

            var weeks = WeekRepository.WeekFetchInfoList(
                DateTime.Now.Year);
            var currentWeek = weeks.First(row => DateTime.Now.Date >= row.StartDate && DateTime.Now.Date <= row.EndDate);
            var currentPeriodStartDate = weeks.Where(row => row.Period == currentWeek.Period).Min(row => row.StartDate);
            var currentPeriodEndDate = weeks.Where(row => row.Period == currentWeek.Period).Max(row => row.EndDate);
            var hours = HourRepository.HourFetchInfoList(
                user, weeks.Min(row => row.StartDate), weeks.Max(row => row.EndDate));
            var hourSummaries = new List<HourSummary>();

            hourSummaries.Add(
                new HourSummary
                    {
                        Name = "Week",
                        Value = (double)hours.Where(row => row.Date >= currentWeek.StartDate.Date && row.Date <= currentWeek.EndDate.Date).Sum(row => row.Duration),
                        NormalValue = 25
                    });
            hourSummaries.Add(
                new HourSummary
                    {
                        Name = "Period",
                        Value = (double)hours.Where(row => row.Date >= currentPeriodStartDate.Date && row.Date <= currentPeriodEndDate.Date).Sum(row => row.Duration),
                        NormalValue = 100
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
    }
}
