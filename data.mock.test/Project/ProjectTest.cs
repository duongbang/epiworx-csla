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
    public class ProjectTest
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
        public void Project_Create()
        {
            var project = ProjectRepository.ProjectNew();

            Assert.IsTrue(project.IsNew, "IsNew should be true");
            Assert.IsTrue(project.IsDirty, "IsDirty should be true");
            Assert.IsFalse(project.IsValid, "IsValid should be false");
            Assert.IsTrue(project.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(project.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(project.IsActive, "IsActive should be true");
            Assert.IsFalse(project.IsArchived, "IsArchived should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(project, DbType.String, "Name"),
                "Name should be required");
        }

        [TestMethod]
        public void Project_Fetch()
        {
            var project = ProjectTestHelper.ProjectNew();

            project = ProjectRepository.ProjectSave(project);

            project = ProjectRepository.ProjectFetch(project.ProjectId);

            Assert.IsTrue(project != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Project_Fetch_Info_List()
        {
            ProjectTestHelper.ProjectAdd();
            ProjectTestHelper.ProjectAdd();

            var projects = ProjectRepository.ProjectFetchInfoList(new ProjectDataCriteria());

            Assert.IsTrue(projects.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Project_Add()
        {
            var project = ProjectTestHelper.ProjectNew();

            Assert.IsTrue(project.IsValid, "IsValid should be true");

            project = ProjectRepository.ProjectSave(project);

            Assert.IsTrue(project.ProjectId != 0, "ProjectId should be a non-zero value");

            ProjectRepository.ProjectFetch(project.ProjectId);
        }

        [TestMethod]
        public void Project_Edit()
        {
            var project = ProjectTestHelper.ProjectNew();

            var name = project.Name;

            Assert.IsTrue(project.IsValid, "IsValid should be true");

            project = ProjectRepository.ProjectSave(project);

            project = ProjectRepository.ProjectFetch(project.ProjectId);

            project.Name = DataHelper.RandomString(20);

            project = ProjectRepository.ProjectSave(project);

            project = ProjectRepository.ProjectFetch(project.ProjectId);

            Assert.IsTrue(project.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Project_Delete()
        {
            var project = ProjectTestHelper.ProjectNew();

            Assert.IsTrue(project.IsValid, "IsValid should be true");

            project = ProjectRepository.ProjectSave(project);

            project = ProjectRepository.ProjectFetch(project.ProjectId);

            ProjectRepository.ProjectDelete(project.ProjectId);

            try
            {
                ProjectRepository.ProjectFetch(project.ProjectId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}