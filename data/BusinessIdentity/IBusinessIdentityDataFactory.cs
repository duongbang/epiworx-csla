using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public interface IBusinessIdentityDataFactory
    {
        BusinessIdentityData Fetch(BusinessIdentityDataCriteria criteria);
    }
}
