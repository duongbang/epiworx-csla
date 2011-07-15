using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class OrganizationUserInfo
    {
        private void Child_Fetch(OrganizationUserMemberData data)
        {
            this.OrganizationUserMemberId = data.OrganizationUserMemberId;
            this.OrganizationId = data.OrganizationId;
            this.OrganizationName = data.Organization.Name;
            this.RoleId = data.RoleId;
            this.UserId = data.UserId;
            this.UserName = data.User.Name;
            this.UserEmail = data.User.Email;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }
    }
}
