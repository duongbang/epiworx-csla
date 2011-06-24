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
    [Authorize]
    public class StatusController : Controller
    {
        public ActionResult Create(int projectId)
        {
            var model = new StatusFormModel();
            var status = StatusRepository.StatusNew();

            status.ProjectId = projectId;

            model.Title = "Status Create";
            model.Status = status;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int projectId, FormCollection collection)
        {
            var model = new StatusFormModel();
            var status = StatusRepository.StatusNew();

            this.Map(collection, status);

            status.ProjectId = projectId;

            status = StatusRepository.StatusSave(status);

            if (status.IsValid)
            {
                return this.RedirectToAction("Details", "Project", new { id = status.ProjectId });
            }

            model.Title = "Status Create";
            model.Status = status;

            ModelHelper.MapBrokenRules(this.ModelState, status);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new StatusFormModel();
            var status = StatusRepository.StatusFetch(id);

            model.Title = "Status Edit";
            model.Status = status;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new StatusFormModel();
            var status = StatusRepository.StatusFetch(id);

            this.Map(collection, status);

            status = StatusRepository.StatusSave(status);

            if (status.IsValid)
            {
                return this.RedirectToAction("Details", "Project", new { id = status.ProjectId });
            }

            model.Title = "Status Edit";
            model.Status = status;

            ModelHelper.MapBrokenRules(this.ModelState, status);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var status = StatusRepository.StatusFetch(id);

            model.Title = "Status Delete";
            model.Id = status.StatusId;
            model.Name = "Status";
            model.Description = status.Name;
            model.ControllerName = "Status";
            model.BackUrl = Url.Action("Details", "Project", new { id = status.ProjectId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var status = StatusRepository.StatusFetch(id);

            StatusRepository.StatusDelete(id);

            return this.RedirectToAction("Details", "Project", new { id = status.ProjectId });
        }

        private void Map(FormCollection source, Status destination)
        {
            destination.Description = source["Description"];
            destination.Name = source["Name"];
            destination.IsActive = ModelHelper.ToBoolean(source["IsActive"]);
            destination.IsArchived = ModelHelper.ToBoolean(source["IsArchived"]);
            destination.IsCompleted = ModelHelper.ToBoolean(source["IsCompleted"]);
            destination.IsStarted = ModelHelper.ToBoolean(source["IsStarted"]);
            destination.Ordinal = int.Parse(source["Ordinal"]);
        }
    }
}
