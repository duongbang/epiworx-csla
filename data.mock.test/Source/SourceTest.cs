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
            var source = SourceRepository.SourceNew();

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
            var source = SourceTestHelper.SourceNew();

            source = SourceRepository.SourceSave(source);

            source = SourceRepository.SourceFetch(source.SourceId);

            Assert.IsTrue(source != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Source_Fetch_Info_List()
        {
            SourceTestHelper.SourceAdd();
            SourceTestHelper.SourceAdd();

            var sources = SourceRepository.SourceFetchInfoList(new SourceDataCriteria());

            Assert.IsTrue(sources.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Source_Add()
        {
            var source = SourceTestHelper.SourceNew();

            Assert.IsTrue(source.IsValid, "IsValid should be true");

            source = SourceRepository.SourceSave(source);

            Assert.IsTrue(source.SourceId != 0, "SourceId should be a non-zero value");

            SourceRepository.SourceFetch(source.SourceId);
        }

        [TestMethod]
        public void Source_Edit()
        {
            var source = SourceTestHelper.SourceNew();

            var name = source.Name;

            Assert.IsTrue(source.IsValid, "IsValid should be true");

            source = SourceRepository.SourceSave(source);

            source = SourceRepository.SourceFetch(source.SourceId);

            source.Name = DataHelper.RandomString(20);

            source = SourceRepository.SourceSave(source);

            source = SourceRepository.SourceFetch(source.SourceId);

            Assert.IsTrue(source.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Source_Delete()
        {
            var source = SourceTestHelper.SourceNew();

            Assert.IsTrue(source.IsValid, "IsValid should be true");

            source = SourceRepository.SourceSave(source);

            source = SourceRepository.SourceFetch(source.SourceId);

            SourceRepository.SourceDelete(source.SourceId);

            try
            {
                SourceRepository.SourceFetch(source.SourceId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}