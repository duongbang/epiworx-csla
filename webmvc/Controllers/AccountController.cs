using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.WebMvc.Helpers;
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

        public ActionResult Register()
        {
            var model = new AccountRegisterModel();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = UserRepository.UserNew();

                Csla.Data.DataMapper.Map(model, user, true);

                user.SetPassword(model.Password);

                user = UserRepository.UserSave(user);

                if (user.IsValid)
                {
                    return this.RedirectToAction("RegisterSuccess");
                }

                ModelHelper.MapBrokenRules(this.ModelState, user);
            }

            return this.View(model);
        }

        public ActionResult RegisterSuccess()
        {
            var model = new AccountRegisterSuccessModel();

            return this.View(model);
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
