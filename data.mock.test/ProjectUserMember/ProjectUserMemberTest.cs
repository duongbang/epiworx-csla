using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Epiworx.Business.Security;
using Epiworx.Data;
using Epiworx.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epiworx.Business;

namespace Epitec.Epilink.Test
{
    [TestClass]
    public class ProjectUserMemberTest
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
        public void ProjectUserMember_Create()
        {
            var projectUserMember = ProjectUserMemberRepository.ProjectUserMemberNew(0, 0);

            Assert.IsTrue(projectUserMember.IsNew, "IsNew should be true");
            Assert.IsTrue(projectUserMember.IsDirty, "IsDirty should be true");
            Assert.IsFalse(projectUserMember.IsValid, "IsValid should be false");
            Assert.IsTrue(projectUserMember.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(projectUserMember.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(projectUserMember, DbType.Int32, "ProjectId"),
                "ProjectId should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(projectUserMember, DbType.Int32, "UserId"),
                "UserId should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(projectUserMember, DbType.Int32, "RoleId"),
                "RoleId should be required");
        }

        [TestMethod]
        public void ProjectUserMember_Fetch()
        {
            var projectUserMember = ProjectUserMemberTestHelper.ProjectUserMemberNew();

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberSave(projectUserMember);

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberFetch(projectUserMember.ProjectUserMemberId);

            Assert.IsTrue(projectUserMember != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void ProjectUserMember_Fetch_Info_List()
        {
            ProjectUserMemberTestHelper.ProjectUserMemberAdd();
            ProjectUserMemberTestHelper.ProjectUserMemberAdd();

            var projectUserMembers = ProjectUserMemberRepository.ProjectUserMemberFetchInfoList(new ProjectUserMemberDataCriteria());

            Assert.IsTrue(projectUserMembers.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void ProjectUserMember_Add()
        {
            var projectUserMember = ProjectUserMemberTestHelper.ProjectUserMemberNew();

            Assert.IsTrue(projectUserMember.IsValid, "IsValid should be true");

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberSave(projectUserMember);

            Assert.IsTrue(projectUserMember.ProjectUserMemberId != 0, "ProjectUserMemberId should be a non-zero value");

            ProjectUserMemberRepository.ProjectUserMemberFetch(projectUserMember.ProjectUserMemberId);
        }

        [TestMethod]
        public void ProjectUserMember_Edit()
        {
            var projectUserMember = ProjectUserMemberTestHelper.ProjectUserMemberNew();

            var roleId = projectUserMember.RoleId;

            Assert.IsTrue(projectUserMember.IsValid, "IsValid should be true");

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberSave(projectUserMember);

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberFetch(projectUserMember.ProjectUserMemberId);

            projectUserMember.RoleId = (int)Role.Reviewer;

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberSave(projectUserMember);

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberFetch(projectUserMember.ProjectUserMemberId);

            Assert.IsTrue(projectUserMember.RoleId != roleId, "RoleId should have different value");
        }

        [TestMethod]
        public void ProjectUserMember_Delete()
        {
            var projectUserMember = ProjectUserMemberTestHelper.ProjectUserMemberNew();

            Assert.IsTrue(projectUserMember.IsValid, "IsValid should be true");

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberSave(projectUserMember);

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberFetch(projectUserMember.ProjectUserMemberId);

            ProjectUserMemberRepository.ProjectUserMemberDelete(projectUserMember.ProjectUserMemberId);

            try
            {
                ProjectUserMemberRepository.ProjectUserMemberFetch(projectUserMember.ProjectUserMemberId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}