using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class FindController : Controller
    {
        public ActionResult Index()
        {
            var model = new FindIndexModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var controllerName = collection["FindCategory"];
            var queryString = collection["FindText"];

            return this.Redirect(Url.Action("Index", controllerName) + "?" + queryString);
        }
    }
}
