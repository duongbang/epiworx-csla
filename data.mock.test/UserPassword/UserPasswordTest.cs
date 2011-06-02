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
    public class UserPasswordTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void User_Password_Fetch()
        {
            BusinessPrincipal.Login("User", "master");

            var user = UserPasswordRepository.UserPasswordFetch();

            Assert.IsFalse(user.IsNew, "IsNew should be false");
            Assert.IsFalse(user.IsDirty, "IsDirty should be false");
            Assert.IsFalse(user.IsValid, "IsValid should be false");
            Assert.IsFalse(user.IsSelfDirty, "IsSelfDirty should be false");
            Assert.IsFalse(user.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "Password"),
                "Password should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "PasswordConfirmation"),
                "PasswordConfirmation should be required");

            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void User_Password_Update()
        {
            BusinessPrincipal.Login("User", "master");

            var userPassword = UserPasswordRepository.UserPasswordFetch();

            var password = DataHelper.RandomString(20);

            userPassword.Password = password;
            userPassword.PasswordConfirmation = userPassword.Password;

            Assert.IsTrue(userPassword.IsValid, "IsValid should be true");

            userPassword = UserPasswordRepository.UserPasswordSave(userPassword);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login("User", password);

            userPassword.Password = "master";
            userPassword.PasswordConfirmation = "master";

            userPassword = UserPasswordRepository.UserPasswordSave(userPassword);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login("User", "master");
        }
    }
}