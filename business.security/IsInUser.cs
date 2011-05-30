using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business.Security
{
    public class IsInUser : Csla.Rules.AuthorizationRule
    {
        public IsInUser(Csla.Rules.AuthorizationActions action)
            : base(action)
        {
        }

        public IsInUser(Csla.Rules.AuthorizationActions action, Csla.Core.IMemberInfo element)
            : base(action, element)
        {
        }

        protected override void Execute(Csla.Rules.AuthorizationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
