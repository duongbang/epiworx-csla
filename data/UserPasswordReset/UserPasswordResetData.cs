using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class UserPasswordResetData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }

        public UserPasswordResetData()
        {
        }
    }
}
