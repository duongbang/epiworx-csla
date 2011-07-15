using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class OrganizationUser
    {
        public OrganizationUserInfo ToOrganizationUserInfo()
        {
            var result = new OrganizationUserInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static OrganizationUser NewOrganizationUser(int organizationId, int userId)
        {
            return Csla.DataPortal.Create<OrganizationUser>(
                new OrganizationUserMemberDataCriteria
                {
                    OrganizationId = organizationId,
                    UserId = userId
                });
        }

        internal static OrganizationUser FetchOrganizationUser(OrganizationUserMemberDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<OrganizationUser>(criteria);
        }

        internal static OrganizationUser FetchOrganizationUser(OrganizationUserMemberData data)
        {
            var result = new OrganizationUser();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteOrganizationUser(OrganizationUserMemberDataCriteria criteria)
        {
            Csla.DataPortal.Delete<OrganizationUser>(criteria);
        }
    }
}
