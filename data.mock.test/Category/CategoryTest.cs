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
    public class CategoryTest
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
        public void Category_Create()
        {
            var category = CategoryRepository.CategoryNew();

            Assert.IsTrue(category.IsNew, "IsNew should be true");
            Assert.IsTrue(category.IsDirty, "IsDirty should be true");
            Assert.IsFalse(category.IsValid, "IsValid should be false");
            Assert.IsTrue(category.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(category.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(category.IsActive, "IsActive should be true");
            Assert.IsFalse(category.IsArchived, "IsArchived should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(category, DbType.String, "Name"),
               "Name should be required");
        }

        [TestMethod]
        public void Category_Fetch()
        {
            var category = CategoryTestHelper.CategoryNew();

            category = CategoryRepository.CategorySave(category);

            category = CategoryRepository.CategoryFetch(category.CategoryId);

            Assert.IsTrue(category != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Category_Fetch_Info_List()
        {
            CategoryTestHelper.CategoryAdd();
            CategoryTestHelper.CategoryAdd();

            var categorys = CategoryRepository.CategoryFetchInfoList(new CategoryDataCriteria());

            Assert.IsTrue(categorys.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Category_Add()
        {
            var category = CategoryTestHelper.CategoryNew();

            Assert.IsTrue(category.IsValid, "IsValid should be true");

            category = CategoryRepository.CategorySave(category);

            Assert.IsTrue(category.CategoryId != 0, "CategoryId should be a non-zero value");

            CategoryRepository.CategoryFetch(category.CategoryId);
        }

        [TestMethod]
        public void Category_Add_With_Duplicate_Name()
        {
            var category = CategoryTestHelper.CategoryNew();

            var name = category.Name;

            CategoryRepository.CategorySave(category);

            category = CategoryRepository.CategoryNew();

            category.Name = name;

            Assert.IsTrue(
                ValidationHelper.ContainsRule(category, "rule://epiworx.business.categoryduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Category_Edit()
        {
            var category = CategoryTestHelper.CategoryNew();

            var name = category.Name;

            Assert.IsTrue(category.IsValid, "IsValid should be true");

            category = CategoryRepository.CategorySave(category);

            category = CategoryRepository.CategoryFetch(category.CategoryId);

            category.Name = DataHelper.RandomString(20);

            category = CategoryRepository.CategorySave(category);

            category = CategoryRepository.CategoryFetch(category.CategoryId);

            Assert.IsTrue(category.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Category_Delete()
        {
            var category = CategoryTestHelper.CategoryNew();

            Assert.IsTrue(category.IsValid, "IsValid should be true");

            category = CategoryRepository.CategorySave(category);

            category = CategoryRepository.CategoryFetch(category.CategoryId);

            CategoryRepository.CategoryDelete(category.CategoryId);

            try
            {
                CategoryRepository.CategoryFetch(category.CategoryId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}