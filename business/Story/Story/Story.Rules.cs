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
    public partial class Story
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new StringRequired(DescriptionProperty));
            this.BusinessRules.AddRule(new IntegerRequired(ProjectIdProperty));
            this.BusinessRules.AddRule(new IntegerRequired(StatusIdProperty));
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
