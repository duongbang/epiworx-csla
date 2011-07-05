using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class TimelineListModel : ModelBase
    {
        public bool IsEditable { get; set; }
        public int SourceId { get; set; }
        public int SourceTypeId { get; set; }
        public IEnumerable<TimelineInfo> Timelines { get; set; }

        public TimelineListModel()
        {
            this.IsEditable = true;
        }
    }
}