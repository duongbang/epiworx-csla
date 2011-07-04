using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Data;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index(
            int? userId,
            string userName)
        {
            var model = new UserListModel();
            var criteria = new UserDataCriteria
                {
                    UserId = userId,
                    Name = userName
                };
            var users = UserRepository.UserFetchInfoList(criteria);

            model.Users = users;

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var model = new UserFormModel();

            model.User = UserRepository.UserFetch(id);

            return this.View(model);
        }

        public ActionResult Create()
        {
            var model = new UserFormModel();

            return this.View(model);
        }

        public ActionResult Create(UserFormModel model)
        {
            return this.RedirectToAction("Details");
        }
    }
}
