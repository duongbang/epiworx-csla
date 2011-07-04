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
    public class TimelineController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult List(
                int sourceId,
                int sourceTypeId)
        {
            var model = new TimelineListModel();
            var criteria = new TimelineDataCriteria
            {
                SourceId = new[] { sourceId },
                SourceTypeId = sourceTypeId
            };
            var timelines = TimelineRepository.TimelineFetchInfoList(criteria);

            model.SourceId = sourceId;
            model.SourceTypeId = sourceTypeId;
            model.Timelines = timelines;
            model.Actions.Add("Add a timeline", Url.Action("Create", new { sourceId, sourceTypeId }), "primary");

            return this.View(model);
        }
        public ActionResult Create(int sourceId, int sourceTypeId)
        {
            var model = new TimelineFormModel();
            var timeline = TimelineRepository.TimelineNew(sourceId, (SourceType)sourceTypeId);

            model.Title = "Timeline Create";
            model.Timeline = timeline;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int sourceId, int sourceTypeId, FormCollection collection)
        {
            var model = new TimelineFormModel();
            var timeline = TimelineRepository.TimelineNew(sourceId, (SourceType)sourceTypeId);

            this.Map(collection, timeline);

            timeline = TimelineRepository.TimelineSave(timeline);

            if (timeline.IsValid)
            {
                return this.Redirect(timeline);
            }

            model.Title = "Timeline Create";
            model.Timeline = timeline;

            ModelHelper.MapBrokenRules(this.ModelState, timeline);

            return this.View(model);
        }

        public ActionResult Redirect(Timeline timeline)
        {
            switch (timeline.SourceTypeName)
            {
                case "User":
                    return this.RedirectToAction("Index", "Home");
                case "Project":
                    return this.RedirectToAction("Details", "Project", new { id = timeline.SourceId });
                default:
                    throw new InvalidSourceException();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = new TimelineFormModel();
            var timeline = TimelineRepository.TimelineFetch(id);

            model.Title = "Timeline Edit";
            model.Timeline = timeline;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new TimelineFormModel();
            var timeline = TimelineRepository.TimelineFetch(id);

            this.Map(collection, timeline);

            timeline = TimelineRepository.TimelineSave(timeline);

            if (timeline.IsValid)
            {
                return this.Redirect(timeline);
            }

            model.Title = "Timeline Edit";
            model.Timeline = timeline;

            ModelHelper.MapBrokenRules(this.ModelState, timeline);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var timeline = TimelineRepository.TimelineFetch(id);

            model.Title = "Timeline Delete";
            model.Id = timeline.TimelineId;
            model.Name = "Timeline";
            model.Description = timeline.Body;
            model.ControllerName = "Timeline";
            model.BackUrl = Url.Action("Details", timeline.SourceTypeName, new { id = timeline.SourceId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var timeline = TimelineRepository.TimelineFetch(id);

            TimelineRepository.TimelineDelete(id);

            return this.Redirect(timeline);
        }

        private void Map(FormCollection source, Timeline destination)
        {
            destination.Body = source["Body"];
        }
    }
}
