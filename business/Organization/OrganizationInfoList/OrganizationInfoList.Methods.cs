using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class OrganizationInfoList
    {
        internal static OrganizationInfoList FetchOrganizationInfoList(OrganizationDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<OrganizationInfoList>(criteria);
        }
    }
}
