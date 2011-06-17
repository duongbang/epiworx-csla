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
    public class FeedSourceTest
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
        public void Feed_Add_Feed_Sources()
        {
            var feed = FeedTestHelper.FeedNew();

            Assert.IsTrue(feed.IsValid, "IsValid should be true");

            feed.Sources.Add(UserTestHelper.UserAdd().UserId, SourceType.User);
            feed.Sources.Add(UserTestHelper.UserAdd().UserId, SourceType.User);

            feed = FeedRepository.FeedSave(feed);

            feed = FeedRepository.FeedFetch(feed.FeedId);

            Assert.IsTrue(feed.Sources.Count() == 2, string.Format("Sources count should be equal to '2' but is '{0}'", feed.Sources.Count()));
        }
    }
}