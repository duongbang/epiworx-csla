using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class ProjectListModel : ModelBase
    {
        public IEnumerable<ProjectInfo> Projects { get; set; }
    }
}