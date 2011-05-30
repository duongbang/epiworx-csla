using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    [Serializable]
    public class BusinessIdentityDataCriteria : Csla.CriteriaBase<BusinessIdentityDataCriteria>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public BusinessIdentityDataCriteria()
            : this(string.Empty, string.Empty)
        {
        }

        public BusinessIdentityDataCriteria(string name)
            : this(name, string.Empty)
        {
        }

        public BusinessIdentityDataCriteria(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}
