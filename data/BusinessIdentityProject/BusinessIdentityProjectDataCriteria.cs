using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    [Serializable]
    public class BusinessIdentityProjectDataCriteria : Csla.CriteriaBase<BusinessIdentityProjectDataCriteria>
    {
        public int UserId { get; set; }

        public BusinessIdentityProjectDataCriteria(int userId)
        {
            this.UserId = userId;
        }
    }
}
