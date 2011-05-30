using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class ProjectData
    {
		public int ProjectId { get; set; }
		public bool IsActive { get; set; }
		public bool IsArchived { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }

        public ProjectData()
        {
        }
    }
}
