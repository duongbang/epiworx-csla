using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class TimelineInfoList
    {
        internal static TimelineInfoList FetchTimelineInfoList(TimelineDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<TimelineInfoList>(criteria);
        }
    }
}
