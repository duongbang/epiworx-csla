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
    public partial class UserPassword
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new StringRequired(PasswordProperty));
            this.BusinessRules.AddRule(new MaxLength(PasswordProperty, 50));
            this.BusinessRules.AddRule(new StringRequired(PasswordConfirmationProperty));
            this.BusinessRules.AddRule(new MaxLength(PasswordConfirmationProperty, 50));
            this.BusinessRules.AddRule(new PropertiesMustMatch(PasswordProperty, PasswordConfirmationProperty));
            this.BusinessRules.AddRule(new Dependency(PasswordProperty, PasswordConfirmationProperty));
            this.BusinessRules.AddRule(new Dependency(PasswordConfirmationProperty, PasswordProperty));
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(UserPassword),
                new IsInUser(AuthorizationActions.EditObject));
        }
    }
}
