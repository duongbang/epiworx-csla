using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedInfoList
    {
        internal static FeedInfoList FetchFeedInfoList(FeedDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<FeedInfoList>(criteria);
        }
    }
}
