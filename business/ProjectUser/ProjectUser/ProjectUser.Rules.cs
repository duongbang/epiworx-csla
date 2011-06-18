using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Epiworx.Business.Security;
using Epiworx.Core.Validation;

namespace Epiworx.Business
{
    public partial class ProjectUser
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new IntegerRequired(ProjectIdProperty));
            this.BusinessRules.AddRule(new IntegerRequired(UserIdProperty));
            this.BusinessRules.AddRule(new IntegerRequired(RoleIdProperty));
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
