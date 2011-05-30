using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    [Serializable]
    public class BusinessIdentityProjectData
    {
        public int ProjectId { get; internal set; }
        public string ProjectName { get; internal set; }
        public int RoleId { get; internal set; }
        public string RoleName { get; internal set; }
    }
}
