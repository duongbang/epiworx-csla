using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class HourFormModel : ModelBase
    {
        public Hour Hour { get; set; }
        public Story Story { get; set; }
    }
}