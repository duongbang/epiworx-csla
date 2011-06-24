using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Models
{
    public class FilterField
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Categories { get; set; }
    }
}