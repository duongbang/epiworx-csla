using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Test.Helpers;

namespace Epiworx.Test.Helpers
{
    public class OrganizationUserTestHelper
    {
        public static OrganizationUser OrganizationUserAdd()
        {
            var organizationUserMember = OrganizationUserTestHelper.OrganizationUserNew();

            organizationUserMember = OrganizationUserRepository.OrganizationUserSave(organizationUserMember);

            return organizationUserMember;
        }

        public static OrganizationUser OrganizationUserNew()
        {
            return OrganizationUserTestHelper.OrganizationUserNew(Role.Collaborator);
        }

        public static OrganizationUser OrganizationUserNew(Role roleId)
        {
            var organization = OrganizationTestHelper.OrganizationAdd();
            var user = UserTestHelper.UserAdd();

            var organizationUserMember = OrganizationUserRepository.OrganizationUserNew(organization.OrganizationId, user.UserId);

            organizationUserMember.RoleId = (int)roleId;

            return organizationUserMember;
        }
    }
}