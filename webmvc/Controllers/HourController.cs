using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class HourController : Controller
    {
        public ActionResult Details(int id)
        {
            var model = new HourFormModel();
            var hour = HourRepository.HourFetch(id);

            model.Title = string.Format("Hour {0:d}", hour.Date);
            model.Hour = hour;
            model.Story = StoryRepository.StoryFetch(hour.StoryId);
            model.Actions.Add("Edit this hour", Url.Action("Edit", new { id }), "primary");
            model.Actions.Add("Add an email", string.Empty);
            model.Actions.Add("Add an attachment", Url.Action("Create", "Note", new { sourceId = id, sourceTypeId = (int)SourceType.Hour }));
            model.Actions.Add("Add a note", Url.Action("Create", "Attachment", new { sourceId = id, sourceTypeId = (int)SourceType.Hour }));

            return this.View(model);
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
