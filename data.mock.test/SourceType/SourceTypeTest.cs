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
    public class SourceTypeTest
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
        public void SourceType_Create()
        {
            var sourceType = SourceTypeRepository.SourceTypeNew();

            Assert.IsTrue(sourceType.IsNew, "IsNew should be true");
            Assert.IsTrue(sourceType.IsDirty, "IsDirty should be true");
            Assert.IsFalse(sourceType.IsValid, "IsValid should be false");
            Assert.IsTrue(sourceType.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(sourceType.IsSelfValid, "IsSelfValid should be false");

            // Assert.IsTrue(ValidationHelper.ContainsRule(sourceType, DbType.String, "Name"),
            //    "Name should be required");
        }

        [TestMethod]
        public void SourceType_Fetch()
        {
            var sourceType = SourceTypeTestHelper.SourceTypeNew();

            sourceType = SourceTypeRepository.SourceTypeSave(sourceType);

            sourceType = SourceTypeRepository.SourceTypeFetch(sourceType.SourceTypeId);

            Assert.IsTrue(sourceType != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void SourceType_Fetch_Info_List()
        {
            SourceTypeTestHelper.SourceTypeAdd();
            SourceTypeTestHelper.SourceTypeAdd();

            var sourceTypes = SourceTypeRepository.SourceTypeFetchInfoList(new SourceTypeDataCriteria());

            Assert.IsTrue(sourceTypes.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void SourceType_Add()
        {
            var sourceType = SourceTypeTestHelper.SourceTypeNew();

            Assert.IsTrue(sourceType.IsValid, "IsValid should be true");

            sourceType = SourceTypeRepository.SourceTypeSave(sourceType);

            Assert.IsTrue(sourceType.SourceTypeId != 0, "SourceTypeId should be a non-zero value");

            SourceTypeRepository.SourceTypeFetch(sourceType.SourceTypeId);
        }

        [TestMethod]
        public void SourceType_Edit()
        {
            var sourceType = SourceTypeTestHelper.SourceTypeNew();

            var name = sourceType.Name;

            Assert.IsTrue(sourceType.IsValid, "IsValid should be true");

            sourceType = SourceTypeRepository.SourceTypeSave(sourceType);

            sourceType = SourceTypeRepository.SourceTypeFetch(sourceType.SourceTypeId);

            sourceType.Name = DataHelper.RandomString(20);

            sourceType = SourceTypeRepository.SourceTypeSave(sourceType);

            sourceType = SourceTypeRepository.SourceTypeFetch(sourceType.SourceTypeId);

            Assert.IsTrue(sourceType.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void SourceType_Delete()
        {
            var sourceType = SourceTypeTestHelper.SourceTypeNew();

            Assert.IsTrue(sourceType.IsValid, "IsValid should be true");

            sourceType = SourceTypeRepository.SourceTypeSave(sourceType);

            sourceType = SourceTypeRepository.SourceTypeFetch(sourceType.SourceTypeId);

            SourceTypeRepository.SourceTypeDelete(sourceType.SourceTypeId);

            try
            {
                SourceTypeRepository.SourceTypeFetch(sourceType.SourceTypeId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}