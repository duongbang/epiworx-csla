using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Business.Security
{
    [Serializable]
    public partial class BusinessPrincipal : IBusinessPrincipal
    {
        public BusinessPrincipal()
        {
        }

        private BusinessPrincipal(IIdentity identity)
        {
            this.Identity = identity;
        }
    }
}
