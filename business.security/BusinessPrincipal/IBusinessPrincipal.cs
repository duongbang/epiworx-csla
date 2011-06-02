using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Business.Security
{
    public interface IBusinessPrincipal : IPrincipal
    {
        bool IsInProject(int projectId);
        bool IsInProjectAndRole(int projectId, Role role);
        bool IsInProjectAndRole(int projectId, params Role[] role);
    }
}
