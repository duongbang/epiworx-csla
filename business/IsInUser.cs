using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;

namespace Epiworx.Business
{
    public class IsInUser : Csla.Rules.AuthorizationRule
    {
        public IsInUser(Csla.Rules.AuthorizationActions action)
            : base(action)
        {
        }

        public IsInUser(Csla.Rules.AuthorizationActions action, Csla.Core.IMemberInfo element)
            : base(action, element)
        {
        }

        protected override void Execute(Csla.Rules.AuthorizationContext context)
        {
            if (context.Target is User)
            {
                var businessIdentity = (IBusinessIdentity)Csla.ApplicationContext.User.Identity;

                if (businessIdentity.UserId == ((User)context.Target).UserId)
                {
                    context.HasPermission = true;

                    return;
                }
            }

            if (context.Target is UserPassword)
            {
                var businessIdentity = (IBusinessIdentity)Csla.ApplicationContext.User.Identity;

                if (businessIdentity.UserId == ((UserPassword)context.Target).UserId)
                {
                    context.HasPermission = true;

                    return;
                }
            }

            context.HasPermission = false;
        }
    }
}
