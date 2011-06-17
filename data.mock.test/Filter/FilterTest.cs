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
    public class FilterTest
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
        public void Filter_Create()
        {
            var filter = FilterRepository.FilterNew();

            Assert.IsTrue(filter.IsNew, "IsNew should be true");
            Assert.IsTrue(filter.IsDirty, "IsDirty should be true");
            Assert.IsFalse(filter.IsValid, "IsValid should be false");
            Assert.IsTrue(filter.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(filter.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(filter, DbType.String, "Name"),
               "Name should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(filter, DbType.String, "FilterQuery"),
               "FilterQuery should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(filter, DbType.Int32, "SourceTypeId"),
               "SourceTypeId should be required");
        }

        [TestMethod]
        public void Filter_Fetch()
        {
            var filter = FilterTestHelper.FilterNew();

            filter = FilterRepository.FilterSave(filter);

            filter = FilterRepository.FilterFetch(filter.FilterId);

            Assert.IsTrue(filter != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Filter_Fetch_Info_List()
        {
            FilterTestHelper.FilterAdd();
            FilterTestHelper.FilterAdd();

            var filters = FilterRepository.FilterFetchInfoList(new FilterDataCriteria());

            Assert.IsTrue(filters.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Filter_Add()
        {
            var filter = FilterTestHelper.FilterNew();

            Assert.IsTrue(filter.IsValid, "IsValid should be true");

            filter = FilterRepository.FilterSave(filter);

            Assert.IsTrue(filter.FilterId != 0, "FilterId should be a non-zero value");

            FilterRepository.FilterFetch(filter.FilterId);
        }

        [TestMethod]
        public void Filter_Edit()
        {
            var filter = FilterTestHelper.FilterNew();

            var name = filter.Name;

            Assert.IsTrue(filter.IsValid, "IsValid should be true");

            filter = FilterRepository.FilterSave(filter);

            filter = FilterRepository.FilterFetch(filter.FilterId);

            filter.Name = DataHelper.RandomString(20);

            filter = FilterRepository.FilterSave(filter);

            filter = FilterRepository.FilterFetch(filter.FilterId);

            Assert.IsTrue(filter.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Filter_Delete()
        {
            var filter = FilterTestHelper.FilterNew();

            Assert.IsTrue(filter.IsValid, "IsValid should be true");

            filter = FilterRepository.FilterSave(filter);

            filter = FilterRepository.FilterFetch(filter.FilterId);

            FilterRepository.FilterDelete(filter.FilterId);

            try
            {
                FilterRepository.FilterFetch(filter.FilterId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}