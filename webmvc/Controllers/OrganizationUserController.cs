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
    public class OrganizationUserController : Controller
    {
        public ActionResult Create(int organizationId)
        {
            var model = new OrganizationUserFormModel();
            var organizationUser = OrganizationUserRepository.OrganizationUserNew(organizationId, 0);

            model.Title = "Organization User Create";
            model.Users = UserRepository.UserFetchInfoList();
            model.OrganizationUser = organizationUser;
            model.OrganizationUsers = OrganizationUserRepository.OrganizationUserFetchInfoList(organizationId);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int organizationId, int userId)
        {
            var model = new OrganizationUserFormModel();
            var organizationUser = OrganizationUserRepository.OrganizationUserNew(organizationId, userId);

            organizationUser.RoleId = (int)Role.Collaborator;

            organizationUser = OrganizationUserRepository.OrganizationUserSave(organizationUser);

            return this.RedirectToAction("Details", "Organization", new { id = organizationUser.OrganizationId });
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var organizationUser = OrganizationUserRepository.OrganizationUserFetch(id);

            model.Title = "Organization User Delete";
            model.Id = organizationUser.OrganizationUserMemberId;
            model.Name = "Organization User";
            model.Description = organizationUser.UserName;
            model.ControllerName = "OrganizationUser";
            model.BackUrl = Url.Action("Details", "Organization", new { id = organizationUser.OrganizationId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var organizationUser = OrganizationUserRepository.OrganizationUserFetch(id);

            OrganizationUserRepository.OrganizationUserDelete(id);

            return this.RedirectToAction("Details", "Organization", new { id = organizationUser.OrganizationId });
        }
    }
}
