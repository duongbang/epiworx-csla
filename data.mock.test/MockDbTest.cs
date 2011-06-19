using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Data;
using Epiworx.Data.Mock;
using Epiworx.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epiworx.Test
{
    [TestClass]
    public class MockDbTest
    {
        [TestMethod]
        public void Create_Database()
        {
            MockDb.Users.Add(new UserData
            {
                UserId = 3,
                Name = "tanis",
                Email = "tanis.sungold@website.com",
                FullName = "Tanis Sungold",
                Salt = "YQmsBzX/4A",
                Password = "D/M0RmZPjxvVpgrZ6QnOmB4EYag=",
                IsActive = true,
                CreatedDate = DateTime.Parse("1/1/2011"),
                ModifiedDate = DateTime.Parse("1/1/2011")
            });

            MockDb.SaveData(MockDb.Users, "c:\\users.xml");
        }

        [TestMethod]
        public void Retrieve_Database()
        {
            MockDb.LoadData(MockDb.Users);
        }
    }
}
