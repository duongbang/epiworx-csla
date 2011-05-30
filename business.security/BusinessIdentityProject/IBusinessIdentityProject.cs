using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Business.Security
{
    public interface IBusinessIdentityProject
    {
        int ProjectId { get; }
        string ProjectName { get; }
        int RoleId { get; }
        string RoleName { get; }
    }
}
