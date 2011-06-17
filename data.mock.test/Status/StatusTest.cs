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
    public class StatusTest
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
        public void Status_Create()
        {
            var status = StatusRepository.StatusNew();

            Assert.IsTrue(status.IsNew, "IsNew should be true");
            Assert.IsTrue(status.IsDirty, "IsDirty should be true");
            Assert.IsFalse(status.IsValid, "IsValid should be false");
            Assert.IsTrue(status.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(status.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(status.IsActive, "IsActive should be true");
            Assert.IsFalse(status.IsArchived, "IsArchived should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(status, DbType.String, "Name"),
               "Name should be required");
        }

        [TestMethod]
        public void Status_Fetch()
        {
            var status = StatusTestHelper.StatusNew();

            status = StatusRepository.StatusSave(status);

            status = StatusRepository.StatusFetch(status.StatusId);

            Assert.IsTrue(status != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Status_Fetch_Info_List()
        {
            StatusTestHelper.StatusAdd();
            StatusTestHelper.StatusAdd();

            var statuss = StatusRepository.StatusFetchInfoList(new StatusDataCriteria());

            Assert.IsTrue(statuss.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Status_Add()
        {
            var status = StatusTestHelper.StatusNew();

            Assert.IsTrue(status.IsValid, "IsValid should be true");

            status = StatusRepository.StatusSave(status);

            Assert.IsTrue(status.StatusId != 0, "StatusId should be a non-zero value");

            StatusRepository.StatusFetch(status.StatusId);
        }

        [TestMethod]
        public void Status_Add_With_Duplicate_Name()
        {
            var status = StatusTestHelper.StatusNew();

            var name = status.Name;

            StatusRepository.StatusSave(status);

            status = StatusRepository.StatusNew();

            status.Name = name;

            Assert.IsTrue(
                ValidationHelper.ContainsRule(status, "rule://epiworx.business.statusduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Status_Edit()
        {
            var status = StatusTestHelper.StatusNew();

            var name = status.Name;

            Assert.IsTrue(status.IsValid, "IsValid should be true");

            status = StatusRepository.StatusSave(status);

            status = StatusRepository.StatusFetch(status.StatusId);

            status.Name = DataHelper.RandomString(20);

            status = StatusRepository.StatusSave(status);

            status = StatusRepository.StatusFetch(status.StatusId);

            Assert.IsTrue(status.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Status_Delete()
        {
            var status = StatusTestHelper.StatusNew();

            Assert.IsTrue(status.IsValid, "IsValid should be true");

            status = StatusRepository.StatusSave(status);

            status = StatusRepository.StatusFetch(status.StatusId);

            StatusRepository.StatusDelete(status.StatusId);

            try
            {
                StatusRepository.StatusFetch(status.StatusId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}