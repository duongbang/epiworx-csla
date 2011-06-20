using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class ProjectFormModel : ModelBase
    {
        public Project Project { get; set; }
        public IEnumerable<StatusInfo> Statuses { get; set; }
        public IEnumerable<ProjectUserInfo> Users { get; set; }
    }
}