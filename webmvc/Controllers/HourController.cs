using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Business.Security;

using Epiworx.Data;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class HourController : Controller
    {
        public ActionResult Index(int? year)
        {
            var model = new HourIndexModel();

            var weeks = WeekRepository.WeekFetchInfoList();
            var startDate = weeks
                .Where(row => row.Year == DateTime.Now.Year || row.Year == year)
                .Min(row => row.StartDate);
            var endDate = weeks
                .Where(row => row.Year == DateTime.Now.Year || row.Year == year)
                .Max(row => row.StartDate);

            model.UserId = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

            var criteria = new HourDataCriteria
            {
                Date = CriteriaHelper.ToDateRangeCriteria(startDate, endDate),
                UserId = model.UserId
            };

            var hours = HourRepository.HourFetchInfoList(criteria);

            model.Hours = hours;
            model.Weeks = weeks.Where(row => row.Year == DateTime.Now.Year || row.Year == year);
            model.Years = weeks.Select(row => row.Year).Distinct();

            return this.View(model);
        }

        public ActionResult List(
            string createdDate,
            string date,
            string isArchived,
            string modifiedDate,
            int? projectId,
            string projectName,
            int? storyId,
            int? userId,
            string userName)
        {
            var model = new HourListModel();
            var criteria = new HourDataCriteria
                {
                    CreatedDate = CriteriaHelper.ToDateRangeCriteria(createdDate),
                    Date = CriteriaHelper.ToDateRangeCriteria(date),
                    IsArchived = CriteriaHelper.ToBoolean(isArchived),
                    ModifiedDate = CriteriaHelper.ToDateRangeCriteria(modifiedDate),
                    ProjectId = CriteriaHelper.ToArray(projectId),
                    ProjectName = projectName,
                    StoryId = storyId,
                    UserId = userId,
                    UserName = userName
                };
            var hours = HourRepository.HourFetchInfoList(criteria);

            model.Hours = hours;

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            return this.RedirectToAction("Edit", new { id });
        }

        public ActionResult Create(int storyId)
        {
            var model = new HourFormModel();
            var hour = HourRepository.HourNew();

            hour.StoryId = storyId;

            model.Title = "Hour Create";
            model.Hour = hour;
            model.Story = StoryRepository.StoryFetch(storyId);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int storyId, FormCollection collection)
        {
            var model = new HourFormModel();
            var hour = HourRepository.HourNew();

            hour.StoryId = storyId;

            this.Map(collection, hour);

            hour = HourRepository.HourSave(hour);

            if (hour.IsValid)
            {
                return this.RedirectToAction("Details", "Story", new { id = hour.StoryId });
            }

            model.Title = "Hour Create";
            model.Hour = hour;
            model.Story = StoryRepository.StoryFetch(storyId);

            ModelHelper.MapBrokenRules(this.ModelState, hour);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new HourFormModel();
            var hour = HourRepository.HourFetch(id);

            model.Title = "Hour Edit";
            model.Hour = hour;
            model.Story = StoryRepository.StoryFetch(hour.StoryId);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new HourFormModel();
            var hour = HourRepository.HourFetch(id);

            this.Map(collection, hour);

            hour = HourRepository.HourSave(hour);

            if (hour.IsValid)
            {
                return this.RedirectToAction("Details", "Story", new { id = hour.StoryId });
            }

            model.Title = "Hour Edit";
            model.Hour = hour;
            model.Story = StoryRepository.StoryFetch(hour.StoryId);

            ModelHelper.MapBrokenRules(this.ModelState, hour);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var hour = HourRepository.HourFetch(id);

            model.Title = "Hour Delete";
            model.Id = hour.HourId;
            model.Name = "Hour";
            model.Description = hour.Date.ToShortDateString();
            model.ControllerName = "Hour";
            model.BackUrl = Url.Action("Details", "Hour", new { id = hour.HourId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            HourRepository.HourDelete(id);

            return this.RedirectToAction("Index", "Home");
        }

        private void Map(FormCollection source, Hour destination)
        {
            destination.Date = DateTime.Parse(source["Date"]);
            destination.Notes = source["Notes"];
            destination.Duration = decimal.Parse(source["Duration"]);
        }
    }
}
