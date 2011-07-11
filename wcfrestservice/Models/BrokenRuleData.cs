using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WcfRestService
{
    public class BrokenRuleData
    {
        public string Property { get; set; }
        public string Description { get; set; }

        public BrokenRuleData()
        {
        }

        public BrokenRuleData(Csla.Rules.BrokenRule data)
        {
            this.Property = data.Property;
            this.Description = data.Description;
        }
    }
}