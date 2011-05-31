using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class UserPasswordData
    {
        public int UserId { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UserPasswordData()
        {
        }
    }
}
