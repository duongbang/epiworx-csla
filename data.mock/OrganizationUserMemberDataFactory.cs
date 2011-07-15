using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class OrganizationUserMemberDataFactory : IOrganizationUserMemberDataFactory
    {
        public OrganizationUserMemberData Fetch(OrganizationUserMemberDataCriteria criteria)
        {
            var data = MockDb.OrganizationUserMembers
                .Where(row => row.OrganizationUserMemberId == criteria.OrganizationUserMemberId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public OrganizationUserMemberData Fetch(OrganizationUserMemberData data)
        {
            data.Organization = MockDb.Organizations
               .Where(row => row.OrganizationId == data.OrganizationId)
               .Single();

            data.User = MockDb.Users
                .Where(row => row.UserId == data.UserId)
                .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public OrganizationUserMemberData[] FetchInfoList(OrganizationUserMemberDataCriteria criteria)
        {
            var query = MockDb.OrganizationUserMembers
                .AsQueryable();

            var organizationUserMembers = query.AsQueryable();

            var data = new List<OrganizationUserMemberData>();

            foreach (var organizationUserMember in organizationUserMembers)
            {
                data.Add(this.Fetch(organizationUserMember));
            }

            return data.ToArray();
        }

        public OrganizationUserMemberData[] FetchLookupInfoList(OrganizationUserMemberDataCriteria criteria)
        {
            var query = MockDb.OrganizationUserMembers
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public OrganizationUserMemberData Create()
        {
            return new OrganizationUserMemberData();
        }

        public OrganizationUserMemberData Update(OrganizationUserMemberData data)
        {
            var organizationUserMember = MockDb.OrganizationUserMembers
                .Where(row => row.OrganizationUserMemberId == data.OrganizationUserMemberId)
                .Single();

            Csla.Data.DataMapper.Map(data, organizationUserMember);

            return data;
        }

        public OrganizationUserMemberData Insert(OrganizationUserMemberData data)
        {
            if (MockDb.OrganizationUserMembers.Count() == 0)
            {
                data.OrganizationUserMemberId = 1;
            }
            else
            {
                data.OrganizationUserMemberId = MockDb.OrganizationUserMembers.Select(row => row.OrganizationUserMemberId).Max() + 1;
            }

            MockDb.OrganizationUserMembers.Add(data);

            return data;
        }

        public void Delete(OrganizationUserMemberDataCriteria criteria)
        {
            var data = MockDb.OrganizationUserMembers
                .Where(row => row.OrganizationUserMemberId == criteria.OrganizationUserMemberId)
                .Single();

            MockDb.OrganizationUserMembers.Remove(data);
        }
    }
}
