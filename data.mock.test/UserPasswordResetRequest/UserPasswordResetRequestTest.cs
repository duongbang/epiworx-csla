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
    public class UserPasswordResetRequestTest
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
        public void User_Password_Reset_Request_Add()
        {
            var userPasswordResetRequest = UserPasswordResetRequestRepository.UserPasswordResetRequestAdd("user@website.com");

            Assert.IsTrue(userPasswordResetRequest.Success, "Return result should be true");
        }
    }
}