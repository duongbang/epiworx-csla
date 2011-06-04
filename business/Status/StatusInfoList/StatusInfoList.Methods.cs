using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class StatusInfoList
    {
        internal static StatusInfoList FetchStatusInfoList(StatusDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<StatusInfoList>(criteria);
        }
    }
}
