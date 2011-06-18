using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class ProjectUserInfoList
    {
        internal static ProjectUserInfoList FetchProjectUserInfoList(ProjectUserMemberDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<ProjectUserInfoList>(criteria);
        }
    }
}
