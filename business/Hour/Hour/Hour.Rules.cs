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
    public partial class Hour
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new IntegerRequired(StoryIdProperty));
            this.BusinessRules.AddRule(new IntegerRequired(UserIdProperty));
            this.BusinessRules.AddRule(new DateRequired(DateProperty));
            this.BusinessRules.AddRule(new DecimalRequired(DurationProperty, 0));
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
