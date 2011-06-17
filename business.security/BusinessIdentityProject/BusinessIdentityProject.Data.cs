using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business.Security
{
    public partial class BusinessIdentityProject
    {
        private void Child_Fetch(BusinessIdentityProjectData data)
        {
            this.ProjectId = data.ProjectId;
            this.ProjectName = data.ProjectName;
            this.RoleId = data.RoleId;
            this.RoleName = data.RoleName;
        }
    }
}