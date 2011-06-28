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
    public partial class Feed
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            this.BusinessRules.AddRule(new StringRequired(ActionProperty));
            this.BusinessRules.AddRule(new MaxLength(ActionProperty, 50));
            this.BusinessRules.AddRule(new IntegerRequired(SourceIdProperty));
            this.BusinessRules.AddRule(new IntegerRequired(SourceTypeIdProperty));
        }
    }
}
