using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class ProjectUserInfo
    {
        private void Child_Fetch(ProjectUserMemberData data)
        {
            this.ProjectUserMemberId = data.ProjectUserMemberId;
            this.ProjectId = data.ProjectId;
            this.ProjectName = data.Project.Name;
            this.RoleId = data.RoleId;
            this.UserId = data.UserId;
            this.UserName = data.User.Name;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }
    }
}
