using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IOrganizationUser
    {
        int OrganizationUserMemberId { get; }
        int OrganizationId { get; }
        string OrganizationName { get; }
        int RoleId { get; }
        int UserId { get; }
        string UserName { get; }
        string UserEmail { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
    }
}
