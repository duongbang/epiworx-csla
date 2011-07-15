using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class OrganizationUserMemberDataFactory : IOrganizationUserMemberDataFactory
    {
        public OrganizationUserMemberData Fetch(OrganizationUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var organizationUserMember = this.Fetch(ctx, criteria)
                    .Single();

                var organizationUserMemberData = new OrganizationUserMemberData();

                this.Fetch(organizationUserMember, organizationUserMemberData);

                return organizationUserMemberData;
            }
        }

        public OrganizationUserMemberData[] FetchInfoList(OrganizationUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var organizationUserMembers = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var organizationUserMemberDataList = new List<OrganizationUserMemberData>();

                foreach (var organizationUserMember in organizationUserMembers)
                {
                    var organizationUserMemberData = new OrganizationUserMemberData();

                    this.Fetch(organizationUserMember, organizationUserMemberData);

                    organizationUserMemberDataList.Add(organizationUserMemberData);
                }

                return organizationUserMemberDataList.ToArray();
            }
        }

        public OrganizationUserMemberData[] FetchLookupInfoList(OrganizationUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var organizationUserMembers = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var organizationUserMemberDataList = new List<OrganizationUserMemberData>();

                foreach (var organizationUserMember in organizationUserMembers)
                {
                    var organizationUserMemberData = new OrganizationUserMemberData();

                    this.Fetch(organizationUserMember, organizationUserMemberData);

                    organizationUserMemberDataList.Add(organizationUserMemberData);
                }

                return organizationUserMemberDataList.ToArray();
            }
        }

        public OrganizationUserMemberData Create()
        {
            return new OrganizationUserMemberData();
        }

        public OrganizationUserMemberData Update(OrganizationUserMemberData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var organizationUserMember =
                    new OrganizationUserMember
                    {
                        OrganizationUserMemberId = data.OrganizationUserMemberId
                    };

                ctx.ObjectContext.OrganizationUserMembers.Attach(organizationUserMember);

                DataMapper.Map(data, organizationUserMember);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public OrganizationUserMemberData Insert(OrganizationUserMemberData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var organizationUserMember = new OrganizationUserMember();

                DataMapper.Map(data, organizationUserMember);

                ctx.ObjectContext.AddToOrganizationUserMembers(organizationUserMember);

                ctx.ObjectContext.SaveChanges();

                data.OrganizationUserMemberId = organizationUserMember.OrganizationUserMemberId;

                return data;
            }
        }

        public void Delete(OrganizationUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var organizationUserMember = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.OrganizationUserMembers.DeleteObject(organizationUserMember);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(OrganizationUserMember organizationUserMember, OrganizationUserMemberData organizationUserMemberData)
        {
            DataMapper.Map(organizationUserMember, organizationUserMemberData);

            organizationUserMemberData.Organization = new OrganizationData();
            DataMapper.Map(organizationUserMember.Organization, organizationUserMemberData.Organization);

            organizationUserMemberData.User = new UserData();
            DataMapper.Map(organizationUserMember.User, organizationUserMemberData.User);

            organizationUserMemberData.CreatedByUser = new UserData();
            DataMapper.Map(organizationUserMember.CreatedByUser, organizationUserMemberData.CreatedByUser);

            organizationUserMemberData.ModifiedByUser = new UserData();
            DataMapper.Map(organizationUserMember.ModifiedByUser, organizationUserMemberData.ModifiedByUser);
        }

        private IQueryable<OrganizationUserMember> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             OrganizationUserMemberDataCriteria criteria)
        {
            IQueryable<OrganizationUserMember> query = ctx.ObjectContext.OrganizationUserMembers
                .Include("Organization")
                .Include("User")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.OrganizationUserMemberId != null)
            {
                query = query.Where(row => row.OrganizationUserMemberId == criteria.OrganizationUserMemberId);
            }

            if (criteria.OrganizationId != null)
            {
                query = query.Where(row => row.OrganizationId == criteria.OrganizationId);
            }

            if (criteria.RoleId != null)
            {
                query = query.Where(row => row.RoleId == criteria.RoleId);
            }

            if (criteria.UserId != null)
            {
                query = query.Where(row => row.UserId == criteria.UserId);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.ModifiedBy != null)
            {
                query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.SortBy != null)
            {
                query = query.OrderBy(string.Format(
                    "{0} {1}",
                    criteria.SortBy,
                    criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            if (criteria.SkipRecords != null)
            {
                query = query.Skip(criteria.SkipRecords.Value);
            }

            if (criteria.MaximumRecords != null)
            {
                query = query.Take(criteria.MaximumRecords.Value);
            }

            return query;
        }
    }
}
