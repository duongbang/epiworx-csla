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
    public class SprintTest
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
        public void Sprint_Create()
        {
            var sprint = SprintRepository.SprintNew(0);

            Assert.IsTrue(sprint.IsNew, "IsNew should be true");
            Assert.IsTrue(sprint.IsDirty, "IsDirty should be true");
            Assert.IsFalse(sprint.IsValid, "IsValid should be false");
            Assert.IsTrue(sprint.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(sprint.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(sprint.IsActive, "IsActive should be true");
            Assert.IsFalse(sprint.IsArchived, "IsArchived should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(sprint, DbType.String, "Name"),
               "Name should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(sprint, DbType.Int32, "ProjectId"),
               "ProjectId should be required");
        }

        [TestMethod]
        public void Sprint_Fetch()
        {
            var sprint = SprintTestHelper.SprintNew();

            sprint = SprintRepository.SprintSave(sprint);

            sprint = SprintRepository.SprintFetch(sprint.SprintId);

            Assert.IsTrue(sprint != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Sprint_Fetch_Info_List()
        {
            SprintTestHelper.SprintAdd();
            SprintTestHelper.SprintAdd();

            var sprints = SprintRepository.SprintFetchInfoList(new SprintDataCriteria());

            Assert.IsTrue(sprints.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Sprint_Add()
        {
            var sprint = SprintTestHelper.SprintNew();

            Assert.IsTrue(sprint.IsValid, "IsValid should be true");

            sprint = SprintRepository.SprintSave(sprint);

            Assert.IsTrue(sprint.SprintId != 0, "SprintId should be a non-zero value");

            SprintRepository.SprintFetch(sprint.SprintId);
        }

        [TestMethod]
        public void Sprint_Edit()
        {
            var sprint = SprintTestHelper.SprintNew();

            var name = sprint.Name;

            Assert.IsTrue(sprint.IsValid, "IsValid should be true");

            sprint = SprintRepository.SprintSave(sprint);

            sprint = SprintRepository.SprintFetch(sprint.SprintId);

            sprint.Name = DataHelper.RandomString(20);

            sprint = SprintRepository.SprintSave(sprint);

            sprint = SprintRepository.SprintFetch(sprint.SprintId);

            Assert.IsTrue(sprint.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Sprint_Delete()
        {
            var sprint = SprintTestHelper.SprintNew();

            Assert.IsTrue(sprint.IsValid, "IsValid should be true");

            sprint = SprintRepository.SprintSave(sprint);

            sprint = SprintRepository.SprintFetch(sprint.SprintId);

            SprintRepository.SprintDelete(sprint.SprintId);

            try
            {
                SprintRepository.SprintFetch(sprint.SprintId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}