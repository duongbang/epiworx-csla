using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class SourceInfoList
    {
        internal static SourceInfoList FetchSourceInfoList(SourceDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<SourceInfoList>(criteria);
        }
    }
}
