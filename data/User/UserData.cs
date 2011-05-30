using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class UserData
    {
		public int UserId { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public bool IsActive { get; set; }
		public bool IsArchived { get; set; }
		public string Name { get; set; }
		public string Salt { get; set; }
		public string Password { get; set; }
		public int RoleId { get; set; }
		public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }

        public UserData()
        {
        }
    }
}
