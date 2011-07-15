using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class OrganizationUserInfoList
    {
        internal static OrganizationUserInfoList FetchOrganizationUserInfoList(OrganizationUserMemberDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<OrganizationUserInfoList>(criteria);
        }
    }
}
