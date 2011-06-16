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

namespace Epiworx.Test
{
    [TestClass]
    public class SourceTest
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
        public void Source_Create()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceNew(project.ProjectId, SourceType.Project, project.Name);

            Assert.IsTrue(source.IsNew, "IsNew should be true");
            Assert.IsTrue(source.IsDirty, "IsDirty should be true");
            Assert.IsFalse(source.IsValid, "IsValid should be false");
            Assert.IsTrue(source.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(source.IsSelfValid, "IsSelfValid should be false");

            // Assert.IsTrue(ValidationHelper.ContainsRule(source, DbType.String, "Name"),
            //    "Name should be required");
        }

        [TestMethod]
        public void Source_Fetch()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceNew(project.ProjectId, SourceType.Project, project.Name);

            source = SourceRepository.SourceSave(source);

            source = SourceRepository.SourceFetch(source.SourceId, SourceType.Project);

            Assert.IsTrue(source != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Source_Add()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceNew(project.ProjectId, SourceType.Project, project.Name);

            Assert.IsTrue(source.IsValid, "IsValid should be true");

            source = SourceRepository.SourceSave(source);

            Assert.IsTrue(source.SourceId != 0, "SourceId should be a non-zero value");

            SourceRepository.SourceFetch(source.SourceId, SourceType.Project);
        }

        [TestMethod]
        public void Source_Delete()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceNew(project.ProjectId, SourceType.Project, project.Name);

            Assert.IsTrue(source.IsValid, "IsValid should be true");

            source = SourceRepository.SourceSave(source);

            source = SourceRepository.SourceFetch(source.SourceId, SourceType.Project);

            SourceRepository.SourceDelete(source.SourceId, SourceType.Project);

            try
            {
                SourceRepository.SourceFetch(source.SourceId, SourceType.Project);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}