using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class WeekInfoList
    {
        internal static WeekInfoList FetchWeekInfoList(WeekDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<WeekInfoList>(criteria);
        }
    }
}
