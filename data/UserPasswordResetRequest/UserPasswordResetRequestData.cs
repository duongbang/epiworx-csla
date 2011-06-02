using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class UserPasswordResetRequestData
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }

        public UserPasswordResetRequestData()
        {
        }
    }
}
