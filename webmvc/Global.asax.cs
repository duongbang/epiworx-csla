using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epiworx.WebMvc
{
    using System.Security.Principal;
    using System.Web.Security;
    using System.Web.SessionState;

    using Epiworx.Business.Security;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (!(HttpContext.Current.Handler is IRequiresSessionState))
            {
                return;
            }

            IPrincipal principal = null;

            try
            {
                principal = (IPrincipal)HttpContext.Current.Session["EPIWORXUSER"];
            }
            catch
            {
                principal = null;
            }

            if (principal == null)
            {
                if (this.User.Identity.IsAuthenticated
                    && this.User.Identity is FormsIdentity)
                {
                    BusinessPrincipal.LoadPrincipal(this.User.Identity.Name);

                    HttpContext.Current.Session["EPIWORXUSER"] = Csla.ApplicationContext.User;

                    this.Response.Redirect(this.Request.Url.PathAndQuery);
                }

                FormsAuthentication.SignOut();

                BusinessPrincipal.Logout();
            }
            else
            {
                Csla.ApplicationContext.User = principal;
            }
        }
    }
}