using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Business.Security
{
    public partial class BusinessPrincipal
    {
        public static bool Login(string username, string password)
        {
            return BusinessPrincipal.SetPrincipal(BusinessIdentity.GetIdentity(username, password));
        }

        public static void LoadPrincipal(string username)
        {
            BusinessPrincipal.SetPrincipal(BusinessIdentity.GetIdentity(username));
        }

        private static bool SetPrincipal(BusinessIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                var principal = new BusinessPrincipal(identity);

                Csla.ApplicationContext.User = principal;
            }

            return identity.IsAuthenticated;
        }

        public static void Logout()
        {
            Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();
        }

        public static BusinessIdentity GetCurrentIdentity()
        {
            return (BusinessIdentity)Csla.ApplicationContext.User.Identity;
        }

        public static BusinessPrincipal GetCurrentPrincipal()
        {
            return (BusinessPrincipal)Csla.ApplicationContext.User;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public bool IsInProject(int projectId)
        {
            var businessIdentity = (IBusinessIdentity)Csla.ApplicationContext.User.Identity;

            return businessIdentity.Projects
                .Any(project => project.ProjectId == projectId);
        }

        public bool IsInProjectAndRole(int projectId, Role role)
        {
            var businessIdentity = (IBusinessIdentity)Csla.ApplicationContext.User.Identity;

            return businessIdentity.Projects
                .Any(project => project.ProjectId == projectId
                    && project.RoleId == (int)role);
        }
    }
}
