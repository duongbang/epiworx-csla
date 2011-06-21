﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class SprintController : Controller
    {
        public ActionResult Details(int id)
        {
            var model = new SprintFormModel();
            var sprint = SprintRepository.SprintFetch(id);

            model.Title = string.Format("Sprint {0}", sprint.Name);
            model.Sprint = sprint;
            model.Statuses = StatusRepository.StatusFetchInfoList(sprint.ProjectId);
            model.Stories = StoryRepository.StoryFetchInfoList(sprint.ProjectId, id);
            model.Actions.Add("Edit this sprint", Url.Action("Edit", new { id }), "primary");
            model.Actions.Add("Add a story", Url.Action("Create", "Story", new { projectId = sprint.ProjectId, sprintId = id }));
            model.Actions.Add("Add an attachment", Url.Action("Create", "Note", new { sourceId = id, sourceTypeId = (int)SourceType.Sprint }));
            model.Actions.Add("Add a note", Url.Action("Create", "Attachment", new { sourceId = id, sourceTypeId = (int)SourceType.Sprint }));

            return this.View(model);
        }

        public ActionResult Create(int projectId)
        {
            var model = new SprintFormModel();
            var sprint = SprintRepository.SprintNew(projectId);

            model.Title = "Sprint Create";
            model.Sprint = sprint;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int projectId, FormCollection collection)
        {
            var model = new SprintFormModel();
            var sprint = SprintRepository.SprintNew(projectId);

            this.Map(collection, sprint);

            sprint = SprintRepository.SprintSave(sprint);

            if (sprint.IsValid)
            {
                return this.RedirectToAction("Details", new { id = sprint.SprintId });
            }

            model.Title = "Sprint Create";
            model.Sprint = sprint;

            ModelHelper.MapBrokenRules(this.ModelState, sprint);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new SprintFormModel();
            var sprint = SprintRepository.SprintFetch(id);

            model.Title = "Sprint Edit";
            model.Sprint = sprint;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new SprintFormModel();
            var sprint = SprintRepository.SprintFetch(id);

            this.Map(collection, sprint);

            sprint = SprintRepository.SprintSave(sprint);

            if (sprint.IsValid)
            {
                return this.RedirectToAction("Details", new { id = sprint.SprintId });
            }

            model.Title = "Sprint Edit";
            model.Sprint = sprint;

            ModelHelper.MapBrokenRules(this.ModelState, sprint);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var sprint = SprintRepository.SprintFetch(id);

            model.Title = "Sprint Delete";
            model.Id = sprint.SprintId;
            model.Name = "Sprint";
            model.Description = sprint.Name;
            model.ControllerName = "Sprint";
            model.BackUrl = Url.Action("Details", "Sprint", new { id = sprint.SprintId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            SprintRepository.SprintDelete(id);

            return this.RedirectToAction("Index", "Home");
        }

        private void Map(FormCollection source, Sprint destination)
        {
            destination.CompletedDate = DateTime.Parse(source["CompletedDate"]);
            destination.IsActive = ModelHelper.ToBoolean(source["IsActive"]);
            destination.IsArchived = ModelHelper.ToBoolean(source["IsArchived"]);
            destination.IsCompleted = ModelHelper.ToBoolean(source["IsCompleted"]);
            destination.EstimatedCompletedDate = DateTime.Parse(source["EstimatedCompletedDate"]);
            destination.EstimatedDuration = int.Parse(source["EstimatedDuration"]);
            destination.Name = source["Name"];
        }
    }
}