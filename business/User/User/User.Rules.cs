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
    public partial class User
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new StringRequired(EmailProperty));
            this.BusinessRules.AddRule(new MaxLength(EmailProperty, 100));
            this.BusinessRules.AddRule(new UserDuplicateEmailCheck { PrimaryProperty = EmailProperty, Priority = 1 });
            this.BusinessRules.AddRule(new StringRequired(FullNameProperty));
            this.BusinessRules.AddRule(new MaxLength(FullNameProperty, 50));
            this.BusinessRules.AddRule(new StringRequired(NameProperty));
            this.BusinessRules.AddRule(new MaxLength(NameProperty, 30));
            this.BusinessRules.AddRule(new UserDuplicateNameCheck { PrimaryProperty = NameProperty, Priority = 1 });
            this.BusinessRules.AddRule(new StringRequired(SaltProperty));
            this.BusinessRules.AddRule(new MaxLength(SaltProperty, 20));
            this.BusinessRules.AddRule(new StringRequired(PasswordProperty));
            this.BusinessRules.AddRule(new MaxLength(PasswordProperty, 50));
        }

        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof(User),
                new IsInUser(AuthorizationActions.EditObject));
            BusinessRules.AddRule(typeof(User),
                new IsInUser(AuthorizationActions.DeleteObject));
        }
    }
}
