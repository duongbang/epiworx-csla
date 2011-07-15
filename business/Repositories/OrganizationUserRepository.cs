using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class OrganizationUserRepository
    {
        public static void AuthorizeOrganizationUser(int organizationId)
        {
            var userId =
                ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

            OrganizationUserRepository.AuthorizeOrganizationUser(organizationId, userId);
        }

        public static void AuthorizeOrganizationUser(int[] organizationIds)
        {
            var userId =
                ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

            OrganizationUserRepository.AuthorizeOrganizationUser(organizationIds, userId);
        }

        public static void AuthorizeOrganizationUser(int organizationId, int userId)
        {
            var organizations = OrganizationRepository.OrganizationFetchInfoList();

            if (!organizations.Any(organization => organization.OrganizationId == organizationId))
            {
                throw new SecurityException("You are not a member of this organization.");
            }
        }

        public static void AuthorizeOrganizationUser(int[] organizationIds, int userId)
        {
            var organizations = OrganizationRepository.OrganizationFetchInfoList();

            foreach (var organizationId in organizationIds)
            {
                if (!organizations.Any(organization => organization.OrganizationId == organizationId))
                {
                    throw new SecurityException("You are not a member of this organization.");
                }
            }
        }

        public static OrganizationUser OrganizationUserFetch(int organizationUserId)
        {
            return OrganizationUser.FetchOrganizationUser(
                new OrganizationUserMemberDataCriteria
                {
                    OrganizationUserMemberId = organizationUserId
                });
        }

        public static OrganizationUser OrganizationUserFetch(int organizationId, int userId)
        {
            return OrganizationUser.FetchOrganizationUser(
                new OrganizationUserMemberDataCriteria
                {
                    OrganizationId = organizationId,
                    UserId = userId
                });
        }

        public static OrganizationUserInfoList OrganizationUserFetchInfoList(int organizationId)
        {
            OrganizationUserRepository.AuthorizeOrganizationUser(organizationId);

            return OrganizationUserInfoList.FetchOrganizationUserInfoList(
                new OrganizationUserMemberDataCriteria
                    {
                        OrganizationId = organizationId
                    });
        }

        public static OrganizationUserInfoList OrganizationUserFetchInfoList(OrganizationUserMemberDataCriteria criteria)
        {
            return OrganizationUserInfoList.FetchOrganizationUserInfoList(criteria);
        }

        public static OrganizationUser OrganizationUserSave(OrganizationUser organizationUser)
        {
            if (!organizationUser.IsValid)
            {
                return organizationUser;
            }

            OrganizationUserRepository.AuthorizeOrganizationUser(organizationUser.OrganizationId);

            OrganizationUser result;

            if (organizationUser.IsNew)
            {
                result = OrganizationUserRepository.OrganizationUserInsert(organizationUser);
            }
            else
            {
                result = OrganizationUserRepository.OrganizationUserUpdate(organizationUser);
            }

            return result;
        }

        public static OrganizationUser OrganizationUserInsert(OrganizationUser organizationUser)
        {
            organizationUser = organizationUser.Save();

            return organizationUser;
        }

        public static OrganizationUser OrganizationUserUpdate(OrganizationUser organizationUser)
        {
            if (!organizationUser.IsDirty)
            {
                return organizationUser;
            }

            organizationUser = organizationUser.Save();

            return organizationUser;
        }

        public static OrganizationUser OrganizationUserAdd(int organizationId, int userId, Role role)
        {
            var organizationUser = OrganizationUser.NewOrganizationUser(organizationId, userId);

            organizationUser.RoleId = (int)role;

            organizationUser = OrganizationUserRepository.OrganizationUserSave(organizationUser);

            return organizationUser;
        }

        internal static OrganizationUser OrganizationUserAdd(int organizationId, int userId, Role role, bool ignoreAuthorization)
        {
            var organizationUser = OrganizationUser.NewOrganizationUser(organizationId, userId);

            organizationUser.RoleId = (int)role;

            if (ignoreAuthorization)
            {
                organizationUser = OrganizationUserRepository.OrganizationUserInsert(organizationUser);
            }
            else
            {
                organizationUser = OrganizationUserRepository.OrganizationUserSave(organizationUser);
            }

            return organizationUser;
        }

        public static OrganizationUser OrganizationUserNew(int organizationId, int userId)
        {
            var organizationUser = OrganizationUser.NewOrganizationUser(organizationId, userId);

            return organizationUser;
        }

        public static bool OrganizationUserDelete(OrganizationUser organizationUser)
        {
            OrganizationUserRepository.AuthorizeOrganizationUser(organizationUser.OrganizationId);

            if (OrganizationUserRepository.OrganizationUserFetch(
                organizationUser.OrganizationId, organizationUser.UserId).RoleId == (int)Role.Owner)
            {
                throw new NotSupportedException("You cannot delete the owner of a organization");
            }

            OrganizationUser.DeleteOrganizationUser(
                new OrganizationUserMemberDataCriteria
                {
                    OrganizationUserMemberId = organizationUser.OrganizationUserMemberId
                });

            return true;
        }

        public static bool OrganizationUserDelete(int organizationId)
        {
            return OrganizationUserRepository.OrganizationUserDelete(
                OrganizationUserRepository.OrganizationUserFetch(organizationId));
        }
    }
}
