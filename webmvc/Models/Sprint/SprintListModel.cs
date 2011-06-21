using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class SprintListModel : ModelBase
    {
        public IEnumerable<SprintInfo> Sprints { get; set; }
    }
}