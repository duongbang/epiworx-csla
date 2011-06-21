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
    public class ProjectUserController : Controller
    {
        public ActionResult Create(int projectId)
        {
            var model = new ProjectUserFormModel();
            var projectUser = ProjectUserRepository.ProjectUserNew(projectId, 0);

            model.Title = "Project User Create";
            model.Users = UserRepository.UserFetchInfoList();
            model.ProjectUser = projectUser;
            model.ProjectUsers = ProjectUserRepository.ProjectUserFetchInfoList(projectId);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int projectId, int userId)
        {
            var model = new ProjectUserFormModel();
            var projectUser = ProjectUserRepository.ProjectUserNew(projectId, userId);

            projectUser.RoleId = (int)Role.Collaborator;

            projectUser = ProjectUserRepository.ProjectUserSave(projectUser);

            return this.RedirectToAction("Details", "Project", new { id = projectUser.ProjectId });
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var projectUser = ProjectUserRepository.ProjectUserFetch(id);

            model.Title = "Project User Delete";
            model.Id = projectUser.ProjectUserMemberId;
            model.Name = "Project User";
            model.Description = projectUser.UserName;
            model.ControllerName = "ProjectUser";
            model.BackUrl = Url.Action("Details", "Project", new { id = projectUser.ProjectId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var projectUser = ProjectUserRepository.ProjectUserFetch(id);

            ProjectUserRepository.ProjectUserDelete(id);

            return this.RedirectToAction("Details", "Project", new { id = projectUser.ProjectId });
        }
    }
}
