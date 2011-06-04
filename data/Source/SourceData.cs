using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class SourceData
    {
		public int SourceId { get; set; }
		public int SourceTypeId { get; set; }
		public string Name { get; set; }
		public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }

        public SourceData()
        {
        }
    }
}
