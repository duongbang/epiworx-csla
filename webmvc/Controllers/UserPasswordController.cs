using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class UserPasswordController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
