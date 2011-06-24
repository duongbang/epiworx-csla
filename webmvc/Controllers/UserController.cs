using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var model = new UserListModel();
            var users = UserRepository.UserFetchInfoList();

            model.Users = users;

            return this.View(model);
        }

        public ActionResult Details(int? id)
        {
            return this.View();
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
