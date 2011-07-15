using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class OrganizationDataFactory : IOrganizationDataFactory
    {
        public OrganizationData Fetch(OrganizationDataCriteria criteria)
        {
            var data = MockDb.Organizations
                .Where(row => row.OrganizationId == criteria.OrganizationId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public OrganizationData Fetch(OrganizationData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public OrganizationData[] FetchInfoList(OrganizationDataCriteria criteria)
        {
            var query = MockDb.Organizations
                .AsQueryable();

            var organizations = query.AsQueryable();

            var data = new List<OrganizationData>();

            foreach (var organization in organizations)
            {
                data.Add(this.Fetch(organization));
            }

            return data.ToArray();
        }

        public OrganizationData[] FetchLookupInfoList(OrganizationDataCriteria criteria)
        {
            var query = MockDb.Organizations
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public OrganizationData Create()
        {
            return new OrganizationData();
        }

        public OrganizationData Update(OrganizationData data)
        {
            var organization = MockDb.Organizations
                .Where(row => row.OrganizationId == data.OrganizationId)
                .Single();

            Csla.Data.DataMapper.Map(data, organization);

            return data;
        }

        public OrganizationData Insert(OrganizationData data)
        {
            if (MockDb.Organizations.Count() == 0)
            {
                data.OrganizationId = 1;
            }
            else
            {
                data.OrganizationId = MockDb.Organizations.Select(row => row.OrganizationId).Max() + 1;
            }

            MockDb.Organizations.Add(data);

            return data;
        }

        public void Delete(OrganizationDataCriteria criteria)
        {
            var data = MockDb.Organizations
                .Where(row => row.OrganizationId == criteria.OrganizationId)
                .Single();

            MockDb.Organizations.Remove(data);
        }
    }
}
