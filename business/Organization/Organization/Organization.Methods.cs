using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Organization
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Name);
        }

        public OrganizationInfo ToOrganizationInfo()
        {
            var result = new OrganizationInfo();

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

        internal static Organization NewOrganization()
        {
            return Csla.DataPortal.Create<Organization>();
        }

        internal static Organization FetchOrganization(OrganizationDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Organization>(criteria);
        }

        internal static Organization FetchOrganization(OrganizationData data)
        {
            var result = new Organization();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteOrganization(OrganizationDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Organization>(criteria);
        }
    }
}
