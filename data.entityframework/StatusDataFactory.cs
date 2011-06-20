using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class StatusDataFactory : IStatusDataFactory
    {
        public StatusData Fetch(StatusDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var status = this.Fetch(ctx, criteria)
                    .Single();

                var statusData = new StatusData();

                this.Fetch(status, statusData);

                return statusData;
            }
        }

        public StatusData[] FetchInfoList(StatusDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var statuss = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var statusDataList = new List<StatusData>();

                foreach (var status in statuss)
                {
                    var statusData = new StatusData();

                    this.Fetch(status, statusData);

                    statusDataList.Add(statusData);
                }

                return statusDataList.ToArray();
            }
        }

        public StatusData[] FetchLookupInfoList(StatusDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var statuss = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var statusDataList = new List<StatusData>();

                foreach (var status in statuss)
                {
                    var statusData = new StatusData();

                    this.Fetch(status, statusData);

                    statusDataList.Add(statusData);
                }

                return statusDataList.ToArray();
            }
        }

        public StatusData Create()
        {
            return new StatusData();
        }

        public StatusData Update(StatusData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var status =
                    new Status
                    {
                        StatusId = data.StatusId
                    };

                ctx.ObjectContext.Statuses.Attach(status);

                Csla.Data.DataMapper.Map(data, status);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public StatusData Insert(StatusData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var status = new Status();

                Csla.Data.DataMapper.Map(data, status);

                ctx.ObjectContext.AddToStatuses(status);

                ctx.ObjectContext.SaveChanges();

                data.StatusId = status.StatusId;

                return data;
            }
        }

        public void Delete(StatusDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var status = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Statuses.DeleteObject(status);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Status status, StatusData statusData)
        {
            DataMapper.Map(status, statusData);

            statusData.Project = new ProjectData();
            DataMapper.Map(status.Project, statusData.Project);

            statusData.CreatedByUser = new UserData();
            DataMapper.Map(status.CreatedByUser, statusData.CreatedByUser);

            statusData.ModifiedByUser = new UserData();
            DataMapper.Map(status.ModifiedByUser, statusData.ModifiedByUser);
        }

        private IQueryable<Status> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             StatusDataCriteria criteria)
        {
            IQueryable<Status> query = ctx.ObjectContext.Statuses
                .Include("Project")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.StatusId != null)
            {
                query = query.Where(row => row.StatusId == criteria.StatusId);
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

            if (criteria.IsCompleted != null)
            {
                query = query.Where(row => row.IsCompleted == criteria.IsCompleted);
            }

            if (criteria.IsStarted != null)
            {
                query = query.Where(row => row.IsStarted == criteria.IsStarted);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.Ordinal != null)
            {
                query = query.Where(row => row.Ordinal == criteria.Ordinal);
            }

            if (criteria.ProjectId != null)
            {
                query = query.Where(row => row.ProjectId == criteria.ProjectId);
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
