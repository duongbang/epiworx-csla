using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserInfoList
    {
        internal static UserInfoList FetchUserInfoList(UserDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<UserInfoList>(criteria);
        }
    }
}
