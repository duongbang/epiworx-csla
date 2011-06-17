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
    public class HourTest
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
        public void Hour_Create()
        {
            var hour = HourRepository.HourNew();

            Assert.IsTrue(hour.IsNew, "IsNew should be true");
            Assert.IsTrue(hour.IsDirty, "IsDirty should be true");
            Assert.IsFalse(hour.IsValid, "IsValid should be false");
            Assert.IsTrue(hour.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(hour.IsSelfValid, "IsSelfValid should be false");

            // Assert.IsTrue(ValidationHelper.ContainsRule(hour, DbType.String, "Name"),
            //    "Name should be required");
        }

        [TestMethod]
        public void Hour_Fetch()
        {
            var hour = HourTestHelper.HourNew();

            hour = HourRepository.HourSave(hour);

            hour = HourRepository.HourFetch(hour.HourId);

            Assert.IsTrue(hour != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Hour_Fetch_Info_List()
        {
            HourTestHelper.HourAdd();
            HourTestHelper.HourAdd();

            var hours = HourRepository.HourFetchInfoList(new HourDataCriteria());

            Assert.IsTrue(hours.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Hour_Add()
        {
            var hour = HourTestHelper.HourNew();

            Assert.IsTrue(hour.IsValid, "IsValid should be true");

            hour = HourRepository.HourSave(hour);

            Assert.IsTrue(hour.HourId != 0, "HourId should be a non-zero value");

            HourRepository.HourFetch(hour.HourId);
        }

        [TestMethod]
        public void Hour_Edit()
        {
            var hour = HourTestHelper.HourNew();

            var notes = hour.Notes;

            Assert.IsTrue(hour.IsValid, "IsValid should be true");

            hour = HourRepository.HourSave(hour);

            hour = HourRepository.HourFetch(hour.HourId);

            hour.Notes = DataHelper.RandomString(20);

            hour = HourRepository.HourSave(hour);

            hour = HourRepository.HourFetch(hour.HourId);

            Assert.IsTrue(hour.Notes != notes, "Name should have different value");
        }

        [TestMethod]
        public void Hour_Delete()
        {
            var hour = HourTestHelper.HourNew();

            Assert.IsTrue(hour.IsValid, "IsValid should be true");

            hour = HourRepository.HourSave(hour);

            hour = HourRepository.HourFetch(hour.HourId);

            HourRepository.HourDelete(hour.HourId);

            try
            {
                HourRepository.HourFetch(hour.HourId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}