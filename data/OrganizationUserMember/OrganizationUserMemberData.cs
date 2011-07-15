using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class OrganizationUserMemberData
    {
        public int OrganizationUserMemberId { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationData Organization { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public UserData User { get; set; }
        public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
