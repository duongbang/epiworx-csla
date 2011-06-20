using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Models
{
    public class DeleteModel : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ControllerName { get; set; }
        public string BackUrl { get; set; }
    }
}