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
    public class ProjectUserTest
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
        public void ProjectUser_Create()
        {
            var projectUserMember = ProjectUserRepository.ProjectUserNew(0, 0);

            Assert.IsTrue(projectUserMember.IsNew, "IsNew should be true");
            Assert.IsTrue(projectUserMember.IsDirty, "IsDirty should be true");
            Assert.IsFalse(projectUserMember.IsValid, "IsValid should be false");
            Assert.IsTrue(projectUserMember.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(projectUserMember.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(projectUserMember, DbType.Int32, "ProjectId"),
                "ProjectId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(projectUserMember, DbType.Int32, "UserId"),
                "UserId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(projectUserMember, DbType.Int32, "RoleId"),
                "RoleId should be required");
        }

        [TestMethod]
        public void ProjectUser_Fetch()
        {
            var projectUserMember = ProjectUserTestHelper.ProjectUserNew();

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            projectUserMember = ProjectUserRepository.ProjectUserFetch(projectUserMember.ProjectUserMemberId);

            Assert.IsTrue(projectUserMember != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void ProjectUser_Fetch_Info_List()
        {
            ProjectUserTestHelper.ProjectUserAdd();
            ProjectUserTestHelper.ProjectUserAdd();

            var projectUserMembers = ProjectUserRepository.ProjectUserFetchInfoList(new ProjectUserMemberDataCriteria());

            Assert.IsTrue(projectUserMembers.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void ProjectUser_Add()
        {
            var projectUserMember = ProjectUserTestHelper.ProjectUserNew();

            Assert.IsTrue(projectUserMember.IsValid, "IsValid should be true");

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            Assert.IsTrue(projectUserMember.ProjectUserMemberId != 0, "ProjectUserMemberId should be a non-zero value");

            ProjectUserRepository.ProjectUserFetch(projectUserMember.ProjectUserMemberId);
        }

        [TestMethod]
        public void ProjectUser_Edit()
        {
            var projectUserMember = ProjectUserTestHelper.ProjectUserNew();

            var roleId = projectUserMember.RoleId;

            Assert.IsTrue(projectUserMember.IsValid, "IsValid should be true");

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            projectUserMember = ProjectUserRepository.ProjectUserFetch(projectUserMember.ProjectUserMemberId);

            projectUserMember.RoleId = (int)Role.Reviewer;

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            projectUserMember = ProjectUserRepository.ProjectUserFetch(projectUserMember.ProjectUserMemberId);

            Assert.IsTrue(projectUserMember.RoleId != roleId, "RoleId should have different value");
        }

        [TestMethod]
        public void ProjectUser_Delete()
        {
            var projectUserMember = ProjectUserTestHelper.ProjectUserNew();

            Assert.IsTrue(projectUserMember.IsValid, "IsValid should be true");

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            projectUserMember = ProjectUserRepository.ProjectUserFetch(projectUserMember.ProjectUserMemberId);

            ProjectUserRepository.ProjectUserDelete(projectUserMember.ProjectUserMemberId);

            try
            {
                ProjectUserRepository.ProjectUserFetch(projectUserMember.ProjectUserMemberId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}