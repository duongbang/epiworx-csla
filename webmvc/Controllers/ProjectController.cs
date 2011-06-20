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
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Details(int id)
        {
            var model = new ProjectFormModel();
            var project = ProjectRepository.ProjectFetch(id);

            model.Title = string.Format("Project {0}", project.Name);
            model.Project = project;
            model.Statuses = StatusRepository.StatusFetchInfoList(id);
            model.Users = ProjectUserRepository.ProjectUserFetchInfoList(id);
            model.Actions.Add("Edit this project", Url.Action("Edit", new { id }), "primary");
            model.Actions.Add("Add a story", Url.Action("Create", "Story", new { projectId = id }));
            model.Actions.Add("Add a sprint", Url.Action("Create", "Sprint", new { projectId = id }));
            model.Actions.Add("Add an attachment", Url.Action("Create", "Note", new { sourceId = id, sourceTypeId = (int)SourceType.Project }));
            model.Actions.Add("Add a note", Url.Action("Create", "Attachment", new { sourceId = id, sourceTypeId = (int)SourceType.Project }));
            model.Actions.Add("Add a collaborator", Url.Action("Create", "ProjectUser", new { projectId = id }));

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
