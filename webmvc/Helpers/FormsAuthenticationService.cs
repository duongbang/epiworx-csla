using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epiworx.WebMvc
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }

            var authenticatedUser = new FormsAuthenticationTicket(userName, createPersistentCookie, 50000);
            var cookie = FormsAuthentication.Encrypt(authenticatedUser);
            var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookie);

            httpCookie.Expires = DateTime.Today.AddYears(1);

            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}