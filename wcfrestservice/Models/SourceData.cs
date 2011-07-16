using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WcfRestService
{
    public class SourceData
    {
        public int SourceId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public SourceData()
        {
        }

        public SourceData(int sourceId, string sourceType, string name)
        {
            this.SourceId = sourceId;
            this.Type = sourceType;
            this.Name = name;
        }
    }
}