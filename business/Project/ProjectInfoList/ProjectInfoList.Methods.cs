using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class ProjectInfoList
    {
        internal static ProjectInfoList FetchProjectInfoList(ProjectDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<ProjectInfoList>(criteria);
        }
    }
}
