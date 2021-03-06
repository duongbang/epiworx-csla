﻿using System;
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
    public class ProjectController : Controller
    {
        public ActionResult Index(
            string createdDate,
            string isActive,
            string isArchived,
            string modifiedDate,
            string projectName)
        {
            var model = new ProjectListModel();
            var criteria =
                new ProjectDataCriteria
                    {
                        CreatedDate = CriteriaHelper.ToDateRangeCriteria(createdDate),
                        IsActive = CriteriaHelper.ToBoolean(isActive),
                        IsArchived = CriteriaHelper.ToBoolean(isArchived),
                        Name = projectName,
                        ModifiedDate = CriteriaHelper.ToDateRangeCriteria(modifiedDate)
                    };
            var projects = ProjectRepository.ProjectFetchInfoList(criteria);

            model.Projects = projects;

            var stories = StoryRepository.StoryFetchInfoList(projects.ToArray(), false);

            model.Stories = stories;

            var timelines = TimelineRepository.TimelineFetchInfoList(
                projects.Select(row => row.ProjectId).Distinct().ToArray(), SourceType.Project);

            model.Timelines = timelines;

            var sprints = SprintRepository.SprintFetchInfoList(projects.ToArray(), false);

            model.Sprints = sprints;

            model.Actions.Add("Add a project", Url.Action("Create"), "primary");

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var model = new ProjectFormModel();
            var project = ProjectRepository.ProjectFetch(id);

            model.Title = string.Format("Project {0}", project.Name);
            model.Project = project;
            model.Notes = NoteRepository.NoteFetchInfoList(id, SourceType.Project);
            model.Attachments = AttachmentRepository.AttachmentFetchInfoList(
                model.Notes.Select(row => row.NoteId).Distinct().ToArray(), SourceType.Note);
            model.Sprints = SprintRepository.SprintFetchInfoList(project);
            model.Statuses = StatusRepository.StatusFetchInfoList(id);
            model.Stories = StoryRepository.StoryFetchInfoList(project, false);
            model.Users = ProjectUserRepository.ProjectUserFetchInfoList(id);
            model.TimelineListModel = new TimelineListModel
            {
                Timelines = TimelineRepository.TimelineFetchInfoList(project),
                SourceId = project.SourceId,
                SourceTypeId = (int)project.SourceType
            };
            model.Actions.Add("Edit this project", Url.Action("Edit", new { id }), "primary");
            model.Actions.Add("Add a story", Url.Action("Create", "Story", new { projectId = id }));
            model.Actions.Add("Add a sprint", Url.Action("Create", "Sprint", new { projectId = id }));
            model.Actions.Add("Add an email", string.Empty);
            model.Actions.Add("Add a note", Url.Action("Create", "Note", new { sourceId = id, sourceTypeId = (int)SourceType.Project }));
            model.Actions.Add("Add a collaborator", Url.Action("Create", "ProjectUser", new { projectId = id }));
            model.Actions.Add("Add a status", Url.Action("Create", "Status", new { projectId = id }));

            return this.View(model);
        }

        public ActionResult Create()
        {
            var model = new ProjectFormModel();
            var project = ProjectRepository.ProjectNew();

            model.Title = "Project Create";
            model.Project = project;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new ProjectFormModel();
            var project = ProjectRepository.ProjectNew();

            this.Map(collection, project);

            project = ProjectRepository.ProjectSave(project);

            if (project.IsValid)
            {
                return this.RedirectToAction("Details", new { id = project.ProjectId });
            }

            model.Title = "Project Create";
            model.Project = project;

            ModelHelper.MapBrokenRules(this.ModelState, project);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new ProjectFormModel();
            var project = ProjectRepository.ProjectFetch(id);

            model.Title = "Project Edit";
            model.Project = project;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new ProjectFormModel();
            var project = ProjectRepository.ProjectFetch(id);

            this.Map(collection, project);

            project = ProjectRepository.ProjectSave(project);

            if (project.IsValid)
            {
                return this.RedirectToAction("Details", new { id = project.ProjectId });
            }

            model.Title = "Project Edit";
            model.Project = project;

            ModelHelper.MapBrokenRules(this.ModelState, project);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var project = ProjectRepository.ProjectFetch(id);

            model.Title = "Project Delete";
            model.Id = project.ProjectId;
            model.Name = "Project";
            model.Description = project.Name;
            model.ControllerName = "Project";
            model.BackUrl = Url.Action("Details", "Project", new { id = project.ProjectId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ProjectRepository.ProjectDelete(id);

            return this.RedirectToAction("Index", "Home");
        }

        private void Map(FormCollection source, Project destination)
        {
            destination.Description = source["Description"];
            destination.Name = source["Name"];
            destination.IsActive = ModelHelper.ToBoolean(source["IsActive"]);
            destination.IsArchived = ModelHelper.ToBoolean(source["IsArchived"]);
        }
    }
}
