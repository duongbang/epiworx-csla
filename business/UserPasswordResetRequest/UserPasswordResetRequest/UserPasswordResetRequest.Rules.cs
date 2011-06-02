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
    public partial class UserPasswordResetRequest
    {
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        protected static void AddObjectAuthorizationRules()
        {
        }
    }
}
