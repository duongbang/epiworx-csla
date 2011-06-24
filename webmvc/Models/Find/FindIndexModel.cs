using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class FindIndexModel : ModelBase
    {
        public IEnumerable<FilterField> FilterFields { get; set; }

        public FindIndexModel()
        {
            this.Title = "Advanced Find";
        }
    }
}