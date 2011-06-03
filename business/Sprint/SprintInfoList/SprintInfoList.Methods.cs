using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class SprintInfoList
    {
        internal static SprintInfoList FetchSprintInfoList(SprintDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<SprintInfoList>(criteria);
        }
    }
}
