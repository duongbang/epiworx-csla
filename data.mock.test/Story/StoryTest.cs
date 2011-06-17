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
    public class StoryTest
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
        public void Story_Create()
        {
            var story = StoryRepository.StoryNew();

            Assert.IsTrue(story.IsNew, "IsNew should be true");
            Assert.IsTrue(story.IsDirty, "IsDirty should be true");
            Assert.IsFalse(story.IsValid, "IsValid should be false");
            Assert.IsTrue(story.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(story.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(story, DbType.Int32, "CategoryId"),
               "CategoryId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(story, DbType.String, "Description"),
               "Description should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(story, DbType.Int32, "ProjectId"),
               "ProjectId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(story, DbType.Int32, "StatusId"),
               "StatusId should be required");
        }

        [TestMethod]
        public void Story_Fetch()
        {
            var story = StoryTestHelper.StoryNew();

            story = StoryRepository.StorySave(story);

            story = StoryRepository.StoryFetch(story.StoryId);

            Assert.IsTrue(story != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Story_Fetch_Info_List()
        {
            StoryTestHelper.StoryAdd();
            StoryTestHelper.StoryAdd();

            var storys = StoryRepository.StoryFetchInfoList(new StoryDataCriteria());

            Assert.IsTrue(storys.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Story_Add()
        {
            var story = StoryTestHelper.StoryNew();

            Assert.IsTrue(story.IsValid, "IsValid should be true");

            story = StoryRepository.StorySave(story);

            Assert.IsTrue(story.StoryId != 0, "StoryId should be a non-zero value");

            StoryRepository.StoryFetch(story.StoryId);
        }

        [TestMethod]
        public void Story_Edit()
        {
            var story = StoryTestHelper.StoryNew();

            var description = story.Description;

            Assert.IsTrue(story.IsValid, "IsValid should be true");

            story = StoryRepository.StorySave(story);

            story = StoryRepository.StoryFetch(story.StoryId);

            story.Description = DataHelper.RandomString(20);

            story = StoryRepository.StorySave(story);

            story = StoryRepository.StoryFetch(story.StoryId);

            Assert.IsTrue(story.Description != description, "Description should have different value");
        }

        [TestMethod]
        public void Story_Delete()
        {
            var story = StoryTestHelper.StoryNew();

            Assert.IsTrue(story.IsValid, "IsValid should be true");

            story = StoryRepository.StorySave(story);

            story = StoryRepository.StoryFetch(story.StoryId);

            StoryRepository.StoryDelete(story.StoryId);

            try
            {
                StoryRepository.StoryFetch(story.StoryId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}