using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    [Serializable]
    public class BusinessIdentityProjectData
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
