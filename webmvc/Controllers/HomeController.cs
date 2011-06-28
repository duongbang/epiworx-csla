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
            model.Projects = ProjectRepository.ProjectFetchInfoList();
            model.StartDate = DateTime.Now.AddDays(-48).ToStartOfWeek().Date;
            model.EndDate = DateTime.Now.ToEndOfWeek().Date;
            model.Hours = HourRepository.HourFetchInfoList(user, model.StartDate, model.EndDate);
            model.FeedListModel = new FeedListModel { Feeds = FeedRepository.FeedFetchInfoList(20) };

            DateTime startDate;
            DateTime currentDate;

            startDate = DateTime.Now.ToStartOfWeek();
            currentDate = startDate;

            var hoursForCurrentWeek = new List<HourSummaryByDate>();

            while (currentDate <= startDate.ToEndOfWeek())
            {
                hoursForCurrentWeek.Add(
                    new HourSummaryByDate
                        {
                            StartDate = currentDate.Date,
                            EndDate = currentDate.Date,
                            Duration = model.Hours.Where(hour => hour.Date.Date == currentDate.Date).Sum(hour => hour.Duration)
                        });
                currentDate = currentDate.AddDays(1);
            }

            model.HoursForCurrentWeek = hoursForCurrentWeek;

            var hoursForTrailingWeeks = new List<HourSummaryByDate>();

            startDate = model.EndDate;
            currentDate = startDate;

            while (currentDate >= model.StartDate)
            {
                hoursForTrailingWeeks.Add(
                      new HourSummaryByDate
                      {
                          StartDate = currentDate.AddDays(-6).Date,
                          EndDate = currentDate.Date,
                          Duration = model.Hours.Where(hour => hour.Date.Date >= currentDate.AddDays(-6).Date && hour.Date.Date <= currentDate.Date).Sum(hour => hour.Duration)
                      });
                currentDate = currentDate.AddDays(-7);
            }

            model.HoursForTrailingWeeks = hoursForTrailingWeeks;

            return View(model);
        }
    }
}
