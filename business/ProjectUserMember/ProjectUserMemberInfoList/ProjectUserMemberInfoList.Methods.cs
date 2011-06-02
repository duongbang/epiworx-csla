using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class ProjectUserMemberInfoList
    {
        internal static ProjectUserMemberInfoList FetchProjectUserMemberInfoList(ProjectUserMemberDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<ProjectUserMemberInfoList>(criteria);
        }
    }
}
