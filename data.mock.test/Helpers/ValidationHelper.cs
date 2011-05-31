using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Csla.Core;

namespace Epiworx.Test.Helpers
{
    public class ValidationHelper
    {
        public static bool ContainsRule(Csla.Core.BusinessBase obj, string name)
        {
            return obj.BrokenRulesCollection.Any(
                 brokenRule => brokenRule.RuleName == name);
        }

        public static bool ContainsRule(Csla.Core.BusinessBase obj, DbType type, string propertyName)
        {
            switch (type)
            {
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                    return obj.BrokenRulesCollection.Any(
                         brokenRule => brokenRule.RuleName == string.Format("rule://epiworx.core.validation.integerrequired/{0}", propertyName))
                            || obj.BrokenRulesCollection.Any(
                                brokenRule => brokenRule.RuleName == string.Format("rule://csla.rules.commonrules.dataannotation/{0}?a=Epitec.Epilink.Core.Validation.IntegerRequiredAttribute", propertyName));
                case DbType.Decimal:
                    return obj.BrokenRulesCollection.Any(
                        brokenRule => brokenRule.RuleName == string.Format("rule://epiworx.core.validation.decimalrequired/{0}", propertyName));
                case DbType.DateTime:
                    return obj.BrokenRulesCollection.Any(
                      brokenRule => brokenRule.RuleName == string.Format("rule://epiworx.core.validation.datetimerequired/{0}", propertyName));
                case DbType.String:
                case DbType.StringFixedLength:
                    return obj.BrokenRulesCollection.Any(
                     brokenRule => brokenRule.RuleName == string.Format("rule://epiworx.core.validation.stringrequired/{0}", propertyName));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
