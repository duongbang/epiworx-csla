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
    public partial class Organization
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new StringRequired(NameProperty));
            this.BusinessRules.AddRule(new MaxLength(NameProperty, 30));
            this.BusinessRules.AddRule(new StringRequired(DescriptionProperty));
            this.BusinessRules.AddRule(new MaxLength(DescriptionProperty, 100));
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
