using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class HourListModel : ModelBase
    {
        public IEnumerable<HourInfo> Hours { get; set; }

        public HourListModel()
        {
            this.FindCategory = "Hour";
        }
    }
}