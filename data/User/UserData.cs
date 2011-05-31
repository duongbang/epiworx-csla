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
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }

        public UserData()
        {
        }
    }
}
