using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    [Serializable]
    public class BusinessIdentityData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public List<BusinessIdentityProjectData> Projects { get; set; }
    }
}
