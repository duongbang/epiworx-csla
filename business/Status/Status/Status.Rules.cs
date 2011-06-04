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
    public partial class Status
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new MaxLength(DescriptionProperty, 300));
            this.BusinessRules.AddRule(new StringRequired(NameProperty));
            this.BusinessRules.AddRule(new MaxLength(NameProperty, 20));
            this.BusinessRules.AddRule(new StatusDuplicateNameCheck { PrimaryProperty = NameProperty, Priority = 1 });
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
