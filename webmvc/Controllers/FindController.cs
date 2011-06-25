using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.WebMvc.Core;
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
            var parameters = new ParameterCollection(collection["FindText"]);
            var controllerName = parameters["find"].Value;
            var queryParameters = new ParameterCollection(parameters, "find");

            return this.Redirect(Url.Action("Index", controllerName) + "?" + queryParameters);
        }
    }
}
