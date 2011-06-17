using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class HourInfoList
    {
        internal static HourInfoList FetchHourInfoList(HourDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<HourInfoList>(criteria);
        }
    }
}
