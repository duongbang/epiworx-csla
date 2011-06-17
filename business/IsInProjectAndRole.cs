using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;

namespace Epiworx.Business
{
    public class IsInProjectAndRole : Csla.Rules.AuthorizationRule
    {
        private Role[] Roles { get; set; }

        public IsInProjectAndRole(Csla.Rules.AuthorizationActions action)
            : base(action)
        {
        }

        public IsInProjectAndRole(Csla.Rules.AuthorizationActions action, params Role[] roles)
            : base(action)
        {
            this.Roles = roles;
        }

        public IsInProjectAndRole(Csla.Rules.AuthorizationActions action, Csla.Core.IMemberInfo element)
            : base(action, element)
        {
        }

        protected override void Execute(Csla.Rules.AuthorizationContext context)
        {
            if (context.Target is Project)
            {
                var principal = (IBusinessPrincipal)Csla.ApplicationContext.User;

                if (principal.IsInProject(((Project)context.Target).ProjectId))
                {
                    context.HasPermission = true;

                    return;
                }
            }

            context.HasPermission = false;
        }
    }
}
