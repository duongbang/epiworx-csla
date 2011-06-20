using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;

namespace Epiworx.Business.Security
{
    [Serializable]
    public partial class BusinessIdentity : IBusinessIdentity
    {
        public BusinessIdentity()
        {
        }
    }
}
