using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class OrganizationData
    {
		public int OrganizationId { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
		public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
		public DateTime CreatedDate { get; set; }

        public OrganizationData()
        {
		    this.OrganizationId = 0;
		    this.Name = string.Empty;
		    this.Description = string.Empty;
		    this.ModifiedBy = 0;
            this.ModifiedByUser = new UserData();
		    this.ModifiedDate = DateTime.MaxValue;
		    this.CreatedBy = 0;
            this.CreatedByUser = new UserData();
		    this.CreatedDate = DateTime.MaxValue;
        }
    }
}
