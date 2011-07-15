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
    public class OrganizationController : Controller
    {
        public ActionResult Change(int id)
        {
            var cookie = new HttpCookie("OrganizationId", id.ToString());

            cookie.Expires = DateTime.Now.AddDays(7);

            this.Response.Cookies.Add(cookie);

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            var model = new OrganizationFormModel();
            var organization = OrganizationRepository.OrganizationNew();

            model.Title = "Organization Create";
            model.Organization = organization;
            model.OrganizationId = -1;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new OrganizationFormModel();
            var organization = OrganizationRepository.OrganizationNew();

            this.Map(collection, organization);

            organization = OrganizationRepository.OrganizationSave(organization);

            if (organization.IsValid)
            {
                return this.RedirectToAction("Index", "Home");
            }

            model.Title = "Organization Create";
            model.Organization = organization;
            model.OrganizationId = -1;

            ModelHelper.MapBrokenRules(this.ModelState, organization);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new OrganizationFormModel();
            var organization = OrganizationRepository.OrganizationFetch(id);

            model.Title = "Organization Edit";
            model.Organization = organization;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new OrganizationFormModel();
            var organization = OrganizationRepository.OrganizationFetch(id);

            this.Map(collection, organization);

            organization = OrganizationRepository.OrganizationSave(organization);

            if (organization.IsValid)
            {
                return this.RedirectToAction("Index", "Home");
            }

            model.Title = "Organization Edit";
            model.Organization = organization;

            ModelHelper.MapBrokenRules(this.ModelState, organization);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var organization = OrganizationRepository.OrganizationFetch(id);

            model.Title = "Organization Delete";
            model.Id = organization.OrganizationId;
            model.Name = "Organization";
            model.Description = organization.Name;
            model.ControllerName = "Organization";
            model.BackUrl = Url.Action("Index", "Home");

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            OrganizationRepository.OrganizationDelete(id);

            return this.RedirectToAction("Index", "Home");
        }

        private void Map(FormCollection source, Organization destination)
        {
            destination.Description = source["Description"];
            destination.Name = source["Name"];
            destination.IsActive = ModelHelper.ToBoolean(source["IsActive"]);
            destination.IsArchived = ModelHelper.ToBoolean(source["IsArchived"]);
        }
    }
}
