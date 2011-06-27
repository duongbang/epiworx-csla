using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class ProjectUserFormModel : ModelBase
    {
        public ProjectUser ProjectUser { get; set; }
        public IEnumerable<UserInfo> Users { get; set; }
        public IEnumerable<ProjectUserInfo> ProjectUsers { get; set; }

        public ProjectUserFormModel()
        {
        }
    }
}