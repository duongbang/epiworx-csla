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
    public class TimelineTest
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
        public void Timeline_Create()
        {
            var timeline = TimelineRepository.TimelineNew();

            Assert.IsTrue(timeline.IsNew, "IsNew should be true");
            Assert.IsTrue(timeline.IsDirty, "IsDirty should be true");
            Assert.IsFalse(timeline.IsValid, "IsValid should be false");
            Assert.IsTrue(timeline.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(timeline.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(timeline, DbType.String, "Body"),
               "Body should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(timeline, DbType.Int32, "SourceId"),
               "SourceId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(timeline, DbType.Int32, "SourceTypeId"),
               "SourceTypeId should be required");
        }

        [TestMethod]
        public void Timeline_Fetch()
        {
            var timeline = TimelineTestHelper.TimelineNew();

            timeline = TimelineRepository.TimelineSave(timeline);

            timeline = TimelineRepository.TimelineFetch(timeline.TimelineId);

            Assert.IsTrue(timeline != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Timeline_Fetch_Info_List()
        {
            TimelineTestHelper.TimelineAdd();
            TimelineTestHelper.TimelineAdd();

            var timelines = TimelineRepository.TimelineFetchInfoList(new TimelineDataCriteria());

            Assert.IsTrue(timelines.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Timeline_Add()
        {
            var timeline = TimelineTestHelper.TimelineNew();

            Assert.IsTrue(timeline.IsValid, "IsValid should be true");

            timeline = TimelineRepository.TimelineSave(timeline);

            Assert.IsTrue(timeline.TimelineId != 0, "TimelineId should be a non-zero value");

            TimelineRepository.TimelineFetch(timeline.TimelineId);
        }

        [TestMethod]
        public void Timeline_Edit()
        {
            var timeline = TimelineTestHelper.TimelineNew();

            var name = timeline.Body;

            Assert.IsTrue(timeline.IsValid, "IsValid should be true");

            timeline = TimelineRepository.TimelineSave(timeline);

            timeline = TimelineRepository.TimelineFetch(timeline.TimelineId);

            timeline.Body = DataHelper.RandomString(20);

            timeline = TimelineRepository.TimelineSave(timeline);

            timeline = TimelineRepository.TimelineFetch(timeline.TimelineId);

            Assert.IsTrue(timeline.Body != name, "Body should have different value");
        }

        [TestMethod]
        public void Timeline_Delete()
        {
            var timeline = TimelineTestHelper.TimelineNew();

            Assert.IsTrue(timeline.IsValid, "IsValid should be true");

            timeline = TimelineRepository.TimelineSave(timeline);

            timeline = TimelineRepository.TimelineFetch(timeline.TimelineId);

            TimelineRepository.TimelineDelete(timeline.TimelineId);

            try
            {
                TimelineRepository.TimelineFetch(timeline.TimelineId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}