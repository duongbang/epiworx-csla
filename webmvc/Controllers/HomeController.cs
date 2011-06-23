using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new HomeIndexModel();
            var user = UserRepository.UserFetch();

            model.User = user;
            model.Projects = ProjectRepository.ProjectFetchInfoList();
            model.StartDate = DateTime.Now.AddDays(-48).ToStartOfWeek().Date;
            model.EndDate = DateTime.Now.ToEndOfWeek().Date;
            model.Hours = HourRepository.HourFetchInfoList(user, model.StartDate, model.EndDate);

            return View(model);
        }
    }
}
