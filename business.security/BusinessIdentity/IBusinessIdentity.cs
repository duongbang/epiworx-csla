using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Business.Security
{
    public interface IBusinessIdentity : IIdentity
    {
        int UserId { get; }
    }
}
