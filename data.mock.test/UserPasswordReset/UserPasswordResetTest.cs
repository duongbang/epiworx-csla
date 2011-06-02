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
    public class UserPasswordResetTest
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
        public void User_Password_Reset_Fetch()
        {
            var userPasswordResetRequest =
                UserPasswordResetRequestRepository.UserPasswordResetRequestAdd("user@website.com");
            var userPasswordReset =
                UserPasswordResetRepository.UserPasswordResetFetch(userPasswordResetRequest.Token);

            Assert.IsFalse(userPasswordReset.IsNew, "IsNew should be false");
            Assert.IsFalse(userPasswordReset.IsDirty, "IsDirty should be false");
            Assert.IsFalse(userPasswordReset.IsValid, "IsValid should be false");
            Assert.IsFalse(userPasswordReset.IsSelfDirty, "IsSelfDirty should be false");
            Assert.IsFalse(userPasswordReset.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(userPasswordReset, DbType.String, "Password"),
                "Password should be required");

            Assert.IsTrue(ValidationHelper.ContainsRule(userPasswordReset, DbType.String, "PasswordConfirmation"),
                "PasswordConfirmation should be required");
        }

        [TestMethod]
        public void User_Password_Reset_Update()
        {
            var userPasswordResetRequest =
                 UserPasswordResetRequestRepository.UserPasswordResetRequestAdd("user@website.com");
            var userPasswordReset =
                UserPasswordResetRepository.UserPasswordResetFetch(userPasswordResetRequest.Token);

            var password = DataHelper.RandomString(20);

            userPasswordReset.Password = password;
            userPasswordReset.PasswordConfirmation = password;

            userPasswordReset = UserPasswordResetRepository.UserPasswordResetSave(userPasswordReset);
        }
    }
}