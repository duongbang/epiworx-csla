using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class SourceTypeData
    {
		public int SourceTypeId { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }

        public SourceTypeData()
        {
        }
    }
}
