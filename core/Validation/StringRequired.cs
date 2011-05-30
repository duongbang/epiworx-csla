using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Core;
using Csla.Properties;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Epiworx.Core.Validation
{
    public class StringRequired : CommonBusinessRule
    {
        public StringRequired(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            this.InputProperties = new List<IPropertyInfo> { primaryProperty };
        }

        protected override void Execute(RuleContext context)
        {
            var value = context.InputPropertyValues[PrimaryProperty];

            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString()))
            {
                var message = string.Format(
                    Resources.StringRequiredRule,
                    PrimaryProperty.FriendlyName);

                context.Results.Add(
                    new RuleResult(RuleName, PrimaryProperty, message) { Severity = Severity });
            }
        }
    }
}
