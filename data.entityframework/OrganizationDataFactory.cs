using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class OrganizationDataFactory : IOrganizationDataFactory
    {
        public OrganizationData Fetch(OrganizationDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var organization = this.Fetch(ctx, criteria)
                    .Single();

                var organizationData = new OrganizationData();

                this.Fetch(organization, organizationData);

                return organizationData;
            }
        }

        public OrganizationData[] FetchInfoList(OrganizationDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var organizations = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var organizationDataList = new List<OrganizationData>();

                foreach (var organization in organizations)
                {
                    var organizationData = new OrganizationData();

                    this.Fetch(organization, organizationData);

                    organizationDataList.Add(organizationData);
                }

                return organizationDataList.ToArray();
            }
        }

        public OrganizationData[] FetchLookupInfoList(OrganizationDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var organizations = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var organizationDataList = new List<OrganizationData>();

                foreach (var organization in organizations)
                {
                    var organizationData = new OrganizationData();

                    this.Fetch(organization, organizationData);

                    organizationDataList.Add(organizationData);
                }

                return organizationDataList.ToArray();
            }
        }

        public OrganizationData Create()
        {
            return new OrganizationData();
        }

        public OrganizationData Update(OrganizationData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var organization =
                    new Organization
                    {
                        OrganizationId = data.OrganizationId
                    };

                ctx.ObjectContext.Organizations.Attach(organization);

                DataMapper.Map(data, organization);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public OrganizationData Insert(OrganizationData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var organization = new Organization();

                DataMapper.Map(data, organization);

                ctx.ObjectContext.AddToOrganizations(organization);

                ctx.ObjectContext.SaveChanges();

                data.OrganizationId = organization.OrganizationId;

                return data;
            }
        }

        public void Delete(OrganizationDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var organization = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Organizations.DeleteObject(organization);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Organization organization, OrganizationData organizationData)
        {
            DataMapper.Map(organization, organizationData);

            organizationData.CreatedByUser = new UserData();
            DataMapper.Map(organization.CreatedByUser, organizationData.CreatedByUser);

            organizationData.ModifiedByUser = new UserData();
            DataMapper.Map(organization.ModifiedByUser, organizationData.ModifiedByUser);
        }

        private IQueryable<Organization> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             OrganizationDataCriteria criteria)
        {
            IQueryable<Organization> query = ctx.ObjectContext.Organizations
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.OrganizationId != null)
            {
                query = query.Where(row => row.OrganizationId == criteria.OrganizationId);
            }

            if (criteria.Description != null)
            {
                query = query.Where(row => row.Description == criteria.Description);
            }

            if (criteria.IsActive != null)
            {
                query = query.Where(row => row.IsActive == criteria.IsActive);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.UserId != null)
            {
                query = query.Join(
                    ctx.ObjectContext.OrganizationUserMembers.Where(pum => pum.UserId == criteria.UserId),
                    p => p.OrganizationId,
                    pum => pum.OrganizationId,
                    (p, cssm) => p);
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

            if (criteria.Text != null)
            {
                query = query.Where(row => row.Name.Contains(criteria.Text));
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
