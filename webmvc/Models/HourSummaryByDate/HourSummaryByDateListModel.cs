using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class HourSummaryByDateListModel : ModelBase
    {
        public IUser User { get; set; }
        public IEnumerable<HourSummaryByDate> Hours { get; set; }
    }
}