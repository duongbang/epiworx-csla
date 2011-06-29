using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class WeekEditModel : ModelBase
    {
        public Week Week { get; set; }

        public WeekEditModel()
        {
        }
    }
}