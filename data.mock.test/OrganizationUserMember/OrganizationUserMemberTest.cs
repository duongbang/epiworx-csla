using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Data;
using Epiworx.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epiworx.Test
{
    [TestClass]
    public class OrganizationUserTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login("Administrator", "master");
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void OrganizationUser_Create()
        {
            var organizationUserMember = OrganizationUserRepository.OrganizationUserNew(0, 0);

            Assert.IsTrue(organizationUserMember.IsNew, "IsNew should be true");
            Assert.IsTrue(organizationUserMember.IsDirty, "IsDirty should be true");
            Assert.IsFalse(organizationUserMember.IsValid, "IsValid should be false");
            Assert.IsTrue(organizationUserMember.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(organizationUserMember.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(organizationUserMember, DbType.Int32, "OrganizationId"),
                "OrganizationId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(organizationUserMember, DbType.Int32, "UserId"),
                "UserId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(organizationUserMember, DbType.Int32, "RoleId"),
                "RoleId should be required");
        }

        [TestMethod]
        public void OrganizationUser_Fetch()
        {
            var organizationUserMember = OrganizationUserTestHelper.OrganizationUserNew();

            organizationUserMember = OrganizationUserRepository.OrganizationUserSave(organizationUserMember);

            organizationUserMember = OrganizationUserRepository.OrganizationUserFetch(organizationUserMember.OrganizationUserMemberId);

            Assert.IsTrue(organizationUserMember != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void OrganizationUser_Fetch_Info_List()
        {
            OrganizationUserTestHelper.OrganizationUserAdd();
            OrganizationUserTestHelper.OrganizationUserAdd();

            var organizationUserMembers = OrganizationUserRepository.OrganizationUserFetchInfoList(new OrganizationUserMemberDataCriteria());

            Assert.IsTrue(organizationUserMembers.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void OrganizationUser_Add()
        {
            var organizationUserMember = OrganizationUserTestHelper.OrganizationUserNew();

            Assert.IsTrue(organizationUserMember.IsValid, "IsValid should be true");

            organizationUserMember = OrganizationUserRepository.OrganizationUserSave(organizationUserMember);

            Assert.IsTrue(organizationUserMember.OrganizationUserMemberId != 0, "OrganizationUserMemberId should be a non-zero value");

            OrganizationUserRepository.OrganizationUserFetch(organizationUserMember.OrganizationUserMemberId);
        }

        [TestMethod]
        public void OrganizationUser_Edit()
        {
            var organizationUserMember = OrganizationUserTestHelper.OrganizationUserNew();

            var roleId = organizationUserMember.RoleId;

            Assert.IsTrue(organizationUserMember.IsValid, "IsValid should be true");

            organizationUserMember = OrganizationUserRepository.OrganizationUserSave(organizationUserMember);

            organizationUserMember = OrganizationUserRepository.OrganizationUserFetch(organizationUserMember.OrganizationUserMemberId);

            organizationUserMember.RoleId = (int)Role.Reviewer;

            organizationUserMember = OrganizationUserRepository.OrganizationUserSave(organizationUserMember);

            organizationUserMember = OrganizationUserRepository.OrganizationUserFetch(organizationUserMember.OrganizationUserMemberId);

            Assert.IsTrue(organizationUserMember.RoleId != roleId, "RoleId should have different value");
        }

        [TestMethod]
        public void OrganizationUser_Delete()
        {
            var organizationUserMember = OrganizationUserTestHelper.OrganizationUserNew();

            Assert.IsTrue(organizationUserMember.IsValid, "IsValid should be true");

            organizationUserMember = OrganizationUserRepository.OrganizationUserSave(organizationUserMember);

            organizationUserMember = OrganizationUserRepository.OrganizationUserFetch(organizationUserMember.OrganizationUserMemberId);

            OrganizationUserRepository.OrganizationUserDelete(organizationUserMember.OrganizationUserMemberId);

            try
            {
                OrganizationUserRepository.OrganizationUserFetch(organizationUserMember.OrganizationUserMemberId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}