using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new HomeIndexModel();

            model.Projects = ProjectRepository.ProjectFetchInfoList();

            return View(model);
        }
    }
}
