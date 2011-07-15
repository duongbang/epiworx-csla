using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class OrganizationRepository
    {
        public static Organization OrganizationFetch(int organizationId)
        {
            return Organization.FetchOrganization(
                new OrganizationDataCriteria
                {
                    OrganizationId = organizationId
                });
        }

        public static OrganizationInfoList OrganizationFetchInfoList()
        {
            return OrganizationRepository.OrganizationFetchInfoList(new OrganizationDataCriteria());
        }

        public static OrganizationInfoList OrganizationFetchInfoList(IUser user)
        {
            return OrganizationInfoList.FetchOrganizationInfoList(
                new OrganizationDataCriteria
                {
                    UserId = user.UserId
                });
        }

        public static OrganizationInfoList OrganizationFetchInfoList(OrganizationDataCriteria criteria)
        {
            // this will ensure that users can only view organizations that they are assigned to
            criteria.UserId =
                ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

            return OrganizationInfoList.FetchOrganizationInfoList(criteria);
        }

        public static Organization OrganizationSave(Organization organization)
        {
            if (!organization.IsValid)
            {
                return organization;
            }

            Organization result;

            if (organization.IsNew)
            {
                result = OrganizationRepository.OrganizationInsert(organization);
            }
            else
            {
                result = OrganizationRepository.OrganizationUpdate(organization);
            }

            return result;
        }

        public static Organization OrganizationInsert(Organization organization)
        {
            organization = organization.Save();

            OrganizationUserRepository.OrganizationUserAdd(
                organization.OrganizationId, ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId, Role.Owner, true);

            return organization;
        }

        public static Organization OrganizationUpdate(Organization organization)
        {
            organization = organization.Save();

            return organization;
        }

        public static Organization OrganizationNew()
        {
            var organization = Organization.NewOrganization();

            return organization;
        }

        public static bool OrganizationDelete(Organization organization)
        {
            Organization.DeleteOrganization(
                new OrganizationDataCriteria
                {
                    OrganizationId = organization.OrganizationId
                });

            return true;
        }

        public static bool OrganizationDelete(int organizationId)
        {
            return OrganizationRepository.OrganizationDelete(
                OrganizationRepository.OrganizationFetch(organizationId));
        }
    }
}
