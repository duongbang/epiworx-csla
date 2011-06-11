using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class StoryInfoList
    {
        internal static StoryInfoList FetchStoryInfoList(StoryDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<StoryInfoList>(criteria);
        }
    }
}
