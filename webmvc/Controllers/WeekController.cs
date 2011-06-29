using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Data;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class WeekController : Controller
    {
        public ActionResult Index(int? year)
        {
            var model = new WeekListModel();
            var weeks = WeekRepository.WeekFetchInfoList(new WeekDataCriteria());

            model.Weeks = weeks.Where(row => year == null || row.Year == year.Value);
            model.Years = weeks.Select(row => row.Year).Distinct();
            model.Actions.Add("Add weeks", Url.Action("Create"), "primary");

            return this.View(model);
        }

        public ActionResult Create()
        {
            var model = new WeekCreateModel();

            model.Title = "Weeks Create";

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(WeekCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                WeekRepository.WeekAdd(model.StartDate, DayOfWeek.Monday, model.NumberOfPeriods, model.Year);

                return this.RedirectToAction("Index", new { year = model.Year });
            }

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new WeekEditModel();
            var week = WeekRepository.WeekFetch(id);

            model.Title = "Week Edit";
            model.Week = week;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new WeekEditModel();
            var week = WeekRepository.WeekFetch(id);

            this.Map(collection, week);

            week = WeekRepository.WeekSave(week);

            if (week.IsValid)
            {
                return this.RedirectToAction("Index", new { year = week.Year });
            }

            model.Title = "Week Edit";
            model.Week = week;

            ModelHelper.MapBrokenRules(this.ModelState, week);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var week = WeekRepository.WeekFetch(id);

            model.Title = "Week Delete";
            model.Id = week.WeekId;
            model.Name = "Week";
            model.Description = week.StartDate.ToShortDateString();
            model.ControllerName = "Week";
            model.BackUrl = Url.Action("Index", "Week", new { year = week.Year });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var week = WeekRepository.WeekFetch(id);

            WeekRepository.WeekDelete(id);

            return this.RedirectToAction("Index", new { year = week.Year });
        }

        private void Map(FormCollection source, Week destination)
        {
            destination.StartDate = DateTime.Parse(source["Description"]);
            destination.EndDate = DateTime.Parse(source["Name"]);
            destination.Period = int.Parse(source["Period"]);
            destination.Year = int.Parse(source["Year"]);
        }
    }
}
