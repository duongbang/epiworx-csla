using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class OrganizationListModel : ModelBase
    {
        public IEnumerable<OrganizationInfo> Organizations { get; set; }
        public IEnumerable<TimelineInfo> Timelines { get; set; }
        public IEnumerable<ProjectInfo> Projects { get; set; }

        public OrganizationListModel()
        {
            this.Title = "Organizations";
        }
    }
}