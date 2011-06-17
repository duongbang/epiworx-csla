using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    using System.ComponentModel;

    [Serializable]
    public class UserData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UserData()
        {
            this.UserId = 0;
            this.Email = string.Empty;
            this.FullName = string.Empty;
            this.IsActive = false;
            this.IsArchived = false;
            this.Name = string.Empty;
            this.Password = string.Empty;
            this.Salt = string.Empty;
            this.Token = string.Empty;
            this.TokenExpirationDate = DateTime.MaxValue;
            this.CreatedDate = DateTime.MaxValue;
            this.ModifiedDate = DateTime.MaxValue;
        }
    }
}
