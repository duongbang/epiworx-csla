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
    public class WeekTest
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
        public void Week_Create()
        {
            var week = WeekRepository.WeekNew();

            Assert.IsTrue(week.IsNew, "IsNew should be true");
            Assert.IsTrue(week.IsDirty, "IsDirty should be true");
            Assert.IsFalse(week.IsValid, "IsValid should be false");
            Assert.IsTrue(week.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(week.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(week, DbType.Date, "StartDate"),
               "StartDate should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(week, DbType.Date, "EndDate"),
               "EndDate should be required");
        }

        [TestMethod]
        public void Week_Fetch()
        {
            var week = WeekTestHelper.WeekNew();

            week = WeekRepository.WeekSave(week);

            week = WeekRepository.WeekFetch(week.WeekId);

            Assert.IsTrue(week != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Week_Fetch_Info_List()
        {
            WeekTestHelper.WeekAdd();
            WeekTestHelper.WeekAdd();

            var weeks = WeekRepository.WeekFetchInfoList(new WeekDataCriteria());

            Assert.IsTrue(weeks.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Week_Add()
        {
            var week = WeekTestHelper.WeekNew();

            Assert.IsTrue(week.IsValid, "IsValid should be true");

            week = WeekRepository.WeekSave(week);

            Assert.IsTrue(week.WeekId != 0, "WeekId should be a non-zero value");

            WeekRepository.WeekFetch(week.WeekId);
        }

        [TestMethod]
        public void Week_Edit()
        {
            var week = WeekTestHelper.WeekNew();

            var name = week.StartDate;

            Assert.IsTrue(week.IsValid, "IsValid should be true");

            week = WeekRepository.WeekSave(week);

            week = WeekRepository.WeekFetch(week.WeekId);

            week.StartDate = week.StartDate.AddDays(1);

            week = WeekRepository.WeekSave(week);

            week = WeekRepository.WeekFetch(week.WeekId);

            Assert.IsTrue(week.StartDate != name, "Name should have different value");
        }

        [TestMethod]
        public void Week_Delete()
        {
            var week = WeekTestHelper.WeekNew();

            Assert.IsTrue(week.IsValid, "IsValid should be true");

            week = WeekRepository.WeekSave(week);

            week = WeekRepository.WeekFetch(week.WeekId);

            WeekRepository.WeekDelete(week.WeekId);

            try
            {
                WeekRepository.WeekFetch(week.WeekId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}