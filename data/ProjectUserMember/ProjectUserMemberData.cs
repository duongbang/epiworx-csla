using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class ProjectUserMemberData
    {
        public int ProjectUserMemberId { get; set; }
        public int ProjectId { get; set; }
        public ProjectData Project { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public UserData User { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
