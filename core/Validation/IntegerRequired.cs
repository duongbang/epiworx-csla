using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Epiworx.Core.Validation
{
    public class IntegerRequired : CommonBusinessRule
    {
        public int EmptyValue { get; internal set; }

        public IntegerRequired(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            this.EmptyValue = 0;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
        }

        public IntegerRequired(Csla.Core.IPropertyInfo primaryProperty, int emptyValue)
            : base(primaryProperty)
        {
            this.EmptyValue = emptyValue;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
        }

        protected override void Execute(RuleContext context)
        {
            var value = context.InputPropertyValues[PrimaryProperty];

            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString())
                || value.ToString() == this.EmptyValue.ToString()
                || Convert.ToInt32(value).ToString() == this.EmptyValue.ToString())
            {
                var message = string.Format(
                    Csla.Properties.Resources.StringRequiredRule,
                    PrimaryProperty.FriendlyName);

                context.Results.Add(
                    new Csla.Rules.RuleResult(RuleName, PrimaryProperty, message) { Severity = Severity });
            }
        }
    }
}
