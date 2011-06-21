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
    public class StoryController : Controller
    {
        public ActionResult Details(int id)
        {
            var model = new StoryFormModel();
            var story = StoryRepository.StoryFetch(id);

            model.Title = string.Format("Story {0}", story.Description);
            model.Story = story;
            model.Statuses = StatusRepository.StatusFetchInfoList(story.ProjectId);
            model.Actions.Add("Edit this story", Url.Action("Edit", new { id }), "primary");
            model.Actions.Add("Add an attachment", Url.Action("Create", "Note", new { sourceId = id, sourceTypeId = (int)SourceType.Story }));
            model.Actions.Add("Add a note", Url.Action("Create", "Attachment", new { sourceId = id, sourceTypeId = (int)SourceType.Story }));

            return this.View(model);
        }

        public ActionResult Create(int projectId, int? sprintId)
        {
            var model = new StoryFormModel();
            var story = StoryRepository.StoryNew();

            story.ProjectId = projectId;
            story.SprintId = sprintId ?? 0;

            model.Title = "Story Create";
            model.Story = story;
            model.Sprints = SprintRepository.SprintFetchInfoList(story.ProjectId);
            model.Statuses = StatusRepository.StatusFetchInfoList(story.ProjectId);
            model.Users = ProjectUserRepository.ProjectUserFetchInfoList(story.ProjectId);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int projectId, int? sprintId, FormCollection collection)
        {
            var model = new StoryFormModel();
            var story = StoryRepository.StoryNew();

            story.ProjectId = projectId;
            story.SprintId = sprintId ?? 0;

            this.Map(collection, story);

            story = StoryRepository.StorySave(story);

            if (story.IsValid)
            {
                return this.RedirectToAction("Details", new { id = story.StoryId });
            }

            model.Title = "Story Create";
            model.Story = story;
            model.Sprints = SprintRepository.SprintFetchInfoList(story.ProjectId);
            model.Statuses = StatusRepository.StatusFetchInfoList(story.ProjectId);
            model.Users = ProjectUserRepository.ProjectUserFetchInfoList(story.ProjectId);

            ModelHelper.MapBrokenRules(this.ModelState, story);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new StoryFormModel();
            var story = StoryRepository.StoryFetch(id);

            model.Title = "Story Edit";
            model.Story = story;
            model.Sprints = SprintRepository.SprintFetchInfoList(story.ProjectId);
            model.Statuses = StatusRepository.StatusFetchInfoList(story.ProjectId);
            model.Users = ProjectUserRepository.ProjectUserFetchInfoList(story.ProjectId);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new StoryFormModel();
            var story = StoryRepository.StoryFetch(id);

            this.Map(collection, story);

            story = StoryRepository.StorySave(story);

            if (story.IsValid)
            {
                return this.RedirectToAction("Details", new { id = story.StoryId });
            }

            model.Title = "Story Edit";
            model.Story = story;
            model.Sprints = SprintRepository.SprintFetchInfoList(story.ProjectId);
            model.Statuses = StatusRepository.StatusFetchInfoList(story.ProjectId);
            model.Users = ProjectUserRepository.ProjectUserFetchInfoList(story.ProjectId);

            ModelHelper.MapBrokenRules(this.ModelState, story);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var story = StoryRepository.StoryFetch(id);

            model.Title = "Story Delete";
            model.Id = story.StoryId;
            model.Name = "Story";
            model.Description = story.Description;
            model.ControllerName = "Story";
            model.BackUrl = Url.Action("Details", "Story", new { id = story.StoryId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            StoryRepository.StoryDelete(id);

            return this.RedirectToAction("Index", "Home");
        }

        private void Map(FormCollection source, Story destination)
        {
            destination.AssignedTo = int.Parse(source["AssignedTo"]);
            destination.Description = source["Description"];
            destination.EstimatedCompletedDate = DateTime.Parse(source["EstimatedCompletedDate"]);
            destination.EstimatedDuration = int.Parse(source["EstimatedDuration"]);
            destination.IsArchived = ModelHelper.ToBoolean(source["IsArchived"]);
            destination.SprintId = int.Parse(source["SprintId"]);
            destination.StatusId = int.Parse(source["StatusId"]);
        }
    }
}