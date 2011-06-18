using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class ProjectUserInfoList : Csla.ReadOnlyListBase<ProjectUserInfoList, ProjectUserInfo>
    {
        private ProjectUserInfoList()
        {
        }
    }
}
