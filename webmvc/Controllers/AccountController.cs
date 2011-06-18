using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Epiworx.Business.Security;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (this.FormsService == null)
            {
                this.FormsService = new FormsAuthenticationService();
            }

            base.Initialize(requestContext);
        }

        public ActionResult LogOn()
        {
            var model = new AccountLogOnModel();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult LogOn(AccountLogOnModel model, string returnUrl)
        {
            //var model = new AccountLogOnModel();

            //model.UserName = collection["UserName"];
            //model.Password = collection["Password"];
            //model.RememberMe = collection["RememberMe"] != null ? true : false;

            if (this.ModelState.IsValid)
            {
                if (this.ValidateUser(model.UserName, model.Password))
                {
                    this.FormsService.SignIn(model.UserName, model.RememberMe);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return this.Redirect(returnUrl);
                    }

                    return this.RedirectToAction("Index", "Home");
                }

                this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            this.FormsService.SignOut();

            BusinessPrincipal.Logout();

            return this.RedirectToAction("Index", "Home");
        }

        public bool ValidateUser(string userName, string password)
        {
            try
            {
                var result = BusinessPrincipal.Login(userName, password);

                this.Session["EPIWORXUSER"] = Csla.ApplicationContext.User;

                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
