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
    public class OrganizationTest
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
        public void Organization_Create()
        {
            var organization = OrganizationRepository.OrganizationNew();

            Assert.IsTrue(organization.IsNew, "IsNew should be true");
            Assert.IsTrue(organization.IsDirty, "IsDirty should be true");
            Assert.IsFalse(organization.IsValid, "IsValid should be false");
            Assert.IsTrue(organization.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(organization.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(organization, DbType.String, "Name"),
                "Name should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(organization, DbType.String, "Description"),
                "Description should be required");
        }

        [TestMethod]
        public void Organization_Fetch()
        {
            var organization = OrganizationTestHelper.OrganizationNew();

            organization = OrganizationRepository.OrganizationSave(organization);

            organization = OrganizationRepository.OrganizationFetch(organization.OrganizationId);

            Assert.IsTrue(organization != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Organization_Fetch_Info_List()
        {
            OrganizationTestHelper.OrganizationAdd();
            OrganizationTestHelper.OrganizationAdd();

            var organizations = OrganizationRepository.OrganizationFetchInfoList(new OrganizationDataCriteria());

            Assert.IsTrue(organizations.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Organization_Add()
        {
            var organization = OrganizationTestHelper.OrganizationNew();

            Assert.IsTrue(organization.IsValid, "IsValid should be true");

            organization = OrganizationRepository.OrganizationSave(organization);

            Assert.IsTrue(organization.OrganizationId != 0, "OrganizationId should be a non-zero value");

            OrganizationRepository.OrganizationFetch(organization.OrganizationId);
        }

        [TestMethod]
        public void Organization_Edit()
        {
            var organization = OrganizationTestHelper.OrganizationNew();

            var name = organization.Name;

            Assert.IsTrue(organization.IsValid, "IsValid should be true");

            organization = OrganizationRepository.OrganizationSave(organization);

            organization = OrganizationRepository.OrganizationFetch(organization.OrganizationId);

            organization.Name = DataHelper.RandomString(20);

            organization = OrganizationRepository.OrganizationSave(organization);

            organization = OrganizationRepository.OrganizationFetch(organization.OrganizationId);

            Assert.IsTrue(organization.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Organization_Delete()
        {
            var organization = OrganizationTestHelper.OrganizationNew();

            Assert.IsTrue(organization.IsValid, "IsValid should be true");

            organization = OrganizationRepository.OrganizationSave(organization);

            organization = OrganizationRepository.OrganizationFetch(organization.OrganizationId);

            OrganizationRepository.OrganizationDelete(organization.OrganizationId);

            try
            {
                OrganizationRepository.OrganizationFetch(organization.OrganizationId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}