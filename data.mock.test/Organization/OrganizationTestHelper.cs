using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class OrganizationTestHelper
    {
        public static Organization OrganizationAdd()
        {
            var organization = OrganizationTestHelper.OrganizationNew();

            organization = OrganizationRepository.OrganizationSave(organization);

            return organization;
        }

        public static Organization OrganizationNew()
        {
            var organization = OrganizationRepository.OrganizationNew();

            organization.Name = DataHelper.RandomString(30);
            organization.Description = DataHelper.RandomString(100);

            return organization;
        }
    }
}