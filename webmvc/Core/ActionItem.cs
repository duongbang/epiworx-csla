using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Epiworx.WebMvc
{
    [Serializable]
    public class ActionItem
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string CssClass { get; set; }
        public string ImageUrl { get; set; }
        public string NavigateUrl { get; set; }

        public ActionItem()
        {
        }
    }
}