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
    public class UserTest
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
        public void User_Create()
        {
            var user = UserRepository.UserNew();

            Assert.IsTrue(user.IsNew, "IsNew should be true");
            Assert.IsTrue(user.IsDirty, "IsDirty should be true");
            Assert.IsFalse(user.IsValid, "IsValid should be false");
            Assert.IsTrue(user.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(user.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(user.IsActive, "IsActive should be true");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(user, DbType.String, "Email"),
                "Email should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(user, DbType.String, "FullName"),
                "FullName should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(user, DbType.String, "Name"),
                "Name should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(user, DbType.String, "Password"),
                "Password should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(user, DbType.String, "Salt"),
                "Salt should be required");
        }

        [TestMethod]
        public void User_Fetch()
        {
            var user = UserTestHelper.UserNew();

            user = UserRepository.UserSave(user);

            user = UserRepository.UserFetch(user.UserId);

            Assert.IsTrue(user != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void User_Fetch_Info_List()
        {
            UserTestHelper.UserAdd();
            UserTestHelper.UserAdd();

            var users = UserRepository.UserFetchInfoList(new UserDataCriteria());

            Assert.IsTrue(users.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void User_Fetch_Lookup_Info_List()
        {
            UserTestHelper.UserAdd();
            UserTestHelper.UserAdd();

            var users = UserRepository.UserFetchInfoList(new UserDataCriteria());

            Assert.IsTrue(users.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void User_Add()
        {
            var user = UserTestHelper.UserNew();

            Assert.IsTrue(user.IsValid, "IsValid should be true");

            user = UserRepository.UserSave(user);

            Assert.IsTrue(user.UserId != 0, "UserId should be a non-zero value");

            UserRepository.UserFetch(user.UserId);
        }

        [TestMethod]
        public void User_Add_With_Bad_Password_Too_Short()
        {
            var user = UserTestHelper.UserNew();

            try
            {
                user.SetPassword("abcd");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void User_Add_With_Bad_Password_Too_Long()
        {
            var user = UserTestHelper.UserNew();

            try
            {
                user.SetPassword("abcdeabcdeabcdeabcdeabcdeabcde123451234512345");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void User_Add_With_Bad_Password_No_Digit()
        {
            var user = UserTestHelper.UserNew();

            try
            {
                user.SetPassword("abcdeABCDE");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is ArgumentOutOfRangeException);
            }
        }

        [TestMethod]
        public void User_Add_With_Duplicate_Name()
        {
            // var user = UserTestHelper.UserNew();

            // var name = user.Name;

            // UserRepository.UserSave(user);

            // user = UserRepository.UserNew();

            // user.Name = name;

            // Assert.IsTrue(ValidationHelper.ContainsRule(user, "rule://epitec.epilink.business.userduplicatenamecheck/Name"),
            //     "Name should not be duplicated");
        }

        [TestMethod]
        public void User_Add_With_Duplicate_Email()
        {
            // var user = UserTestHelper.UserNew();

            // var email = user.Email;

            // UserRepository.UserSave(user);

            // user = UserRepository.UserNew();

            // user.Email = email;

            // Assert.IsTrue(ValidationHelper.ContainsRule(user, "rule://epitec.epilink.business.userduplicateemailcheck/Email"),
            //     "Email should not be duplicated");
        }

        [TestMethod]
        public void User_Edit()
        {
            var user = UserRepository.UserFetch();

            var fullName = user.FullName;

            user.FullName = DataHelper.RandomString(30);

            user = UserRepository.UserSave(user);

            user = UserRepository.UserFetch(user.UserId);

            Assert.IsTrue(user.FullName != fullName, "FullName should have different value");
        }
    }
}