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

            feed.Sources.Add(1, SourceType.User);
            feed.Sources.Add(2, SourceType.User);

            feed = FeedRepository.FeedSave(feed);

            feed = FeedRepository.FeedFetch(feed.FeedId);

            Assert.IsTrue(feed.Sources.Count() == 2, string.Format("Sources count should be equal to '2' but is '{0}'", feed.Sources.Count()));
        }
    }
}