using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace Epiworx.Core.Validation
{
    public class PropertiesMustMatch : CommonBusinessRule
    {
        private IPropertyInfo CompareToProperty { get; set; }

        public PropertiesMustMatch(IPropertyInfo primaryProperty, IPropertyInfo compareToProperty)
            : base(primaryProperty)
        {
            this.CompareToProperty = compareToProperty;
            this.InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty, compareToProperty };
        }

        protected override void Execute(RuleContext context)
        {
            var value1 = (IComparable)context.InputPropertyValues[this.PrimaryProperty];
            var value2 = (IComparable)context.InputPropertyValues[this.CompareToProperty];

            if (value1.CompareTo(value2) != 0)
            {
                context.AddErrorResult(string.Format("{0} must match {1}", this.PrimaryProperty.FriendlyName, this.CompareToProperty.FriendlyName));
            }
        }
    }
}
