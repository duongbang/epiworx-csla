using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    using Epiworx.WebMvc.Helpers;

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

        private void Map(FormCollection source, Project destination)
        {
            destination.Description = source["Description"];
            destination.Name = source["Name"];
            destination.IsActive = ModelHelper.ToBoolean(source["IsActive"]);
            destination.IsArchived = ModelHelper.ToBoolean(source["IsArchived"]);
        }
    }
}
