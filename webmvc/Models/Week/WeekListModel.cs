using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class WeekListModel : ModelBase
    {
        public IEnumerable<int> Years { get; set; }
        public IEnumerable<WeekInfo> Weeks { get; set; }

        public WeekListModel()
        {
        }
    }
}