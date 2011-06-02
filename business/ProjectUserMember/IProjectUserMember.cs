using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IProjectUserMember
    {
        int ProjectUserMemberId { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        int RoleId { get; }
        int UserId { get; }
        string UserName { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
    }
}
