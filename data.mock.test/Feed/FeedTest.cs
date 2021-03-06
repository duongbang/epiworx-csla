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
    public class FeedTest
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
        public void Feed_Fetch_Info_List()
        {
            Project project;

            project = ProjectTestHelper.ProjectAdd();
            FeedTestHelper.FeedAdd(project.SourceType, project.SourceId);

            project = ProjectTestHelper.ProjectAdd();
            FeedTestHelper.FeedAdd(project.SourceType, project.SourceId);

            var feeds = FeedRepository.FeedFetchInfoList(new FeedDataCriteria());

            Assert.IsTrue(feeds.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Feed_Add()
        {
            var project = ProjectTestHelper.ProjectAdd();
            var feed = FeedTestHelper.FeedNew(project.SourceType, project.SourceId);

            Assert.IsTrue(feed.IsValid, "IsValid should be true");

            feed = FeedRepository.FeedSave(feed);

            Assert.IsTrue(feed.FeedId != 0, "FeedId should be a non-zero value");
        }
    }
}