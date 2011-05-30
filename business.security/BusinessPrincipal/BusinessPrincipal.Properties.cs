using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Business.Security
{
    public partial class BusinessPrincipal
    {
        public IIdentity Identity { get; internal set; }
    }
}
