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
            Assert.IsTrue(source.IsSelfDirty, "IsSelfDirty should be true");
        }

        [TestMethod]
        public void Source_Fetch()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceFetch(project.ProjectId, SourceType.Project);

            Assert.IsTrue(source != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Source_Add()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceFetch(project.ProjectId, SourceType.Project);

            Assert.IsTrue(source != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Source_Delete()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var source = SourceRepository.SourceFetch(project.ProjectId, SourceType.Project);

            Assert.IsTrue(source != null, "Row returned should not equal null");

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