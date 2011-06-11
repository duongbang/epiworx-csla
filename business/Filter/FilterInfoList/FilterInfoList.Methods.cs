using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FilterInfoList
    {
        internal static FilterInfoList FetchFilterInfoList(FilterDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<FilterInfoList>(criteria);
        }
    }
}
