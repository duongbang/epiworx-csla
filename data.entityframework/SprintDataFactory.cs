using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class SprintDataFactory : ISprintDataFactory
    {
        public SprintData Fetch(SprintDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var sprint = this.Fetch(ctx, criteria)
                    .Single();

                var sprintData = new SprintData();

                this.Fetch(sprint, sprintData);

                return sprintData;
            }
        }

        public SprintData[] FetchInfoList(SprintDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var sprints = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var sprintDataList = new List<SprintData>();

                foreach (var sprint in sprints)
                {
                    var sprintData = new SprintData();

                    this.Fetch(sprint, sprintData);

                    sprintDataList.Add(sprintData);
                }

                return sprintDataList.ToArray();
            }
        }

        public SprintData[] FetchLookupInfoList(SprintDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var sprints = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var sprintDataList = new List<SprintData>();

                foreach (var sprint in sprints)
                {
                    var sprintData = new SprintData();

                    this.Fetch(sprint, sprintData);

                    sprintDataList.Add(sprintData);
                }

                return sprintDataList.ToArray();
            }
        }

        public SprintData Create()
        {
            return new SprintData();
        }

        public SprintData Update(SprintData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var sprint =
                    new Sprint
                    {
                        SprintId = data.SprintId
                    };

                ctx.ObjectContext.Sprints.Attach(sprint);

                DataMapper.Map(data, sprint);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public SprintData Insert(SprintData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var sprint = new Sprint();

                DataMapper.Map(data, sprint);

                ctx.ObjectContext.AddToSprints(sprint);

                ctx.ObjectContext.SaveChanges();

                data.SprintId = sprint.SprintId;

                return data;
            }
        }

        public void Delete(SprintDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var sprint = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Sprints.DeleteObject(sprint);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Sprint sprint, SprintData sprintData)
        {
            DataMapper.Map(sprint, sprintData);

            sprintData.Project = new ProjectData();
            DataMapper.Map(sprint.Project, sprintData.Project);

            sprintData.CreatedByUser = new UserData();
            DataMapper.Map(sprint.CreatedByUser, sprintData.CreatedByUser);

            sprintData.ModifiedByUser = new UserData();
            DataMapper.Map(sprint.ModifiedByUser, sprintData.ModifiedByUser);
        }

        private IQueryable<Sprint> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             SprintDataCriteria criteria)
        {
            IQueryable<Sprint> query = ctx.ObjectContext.Sprints
                .Include("Project")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.SprintId != null)
            {
                query = query.Where(row => row.SprintId == criteria.SprintId);
            }

            if (criteria.CompletedDate != null
                && criteria.CompletedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CompletedDate >= criteria.CompletedDate.DateFrom);
            }

            if (criteria.CompletedDate != null
                && (criteria.CompletedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.CompletedDate <= criteria.CompletedDate.DateTo);
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

            if (criteria.Duration != null)
            {
                query = query.Where(row => row.Duration == criteria.Duration);
            }

            if (criteria.EstimatedCompletedDate != null
                && criteria.EstimatedCompletedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.EstimatedCompletedDate >= criteria.EstimatedCompletedDate.DateFrom);
            }

            if (criteria.EstimatedCompletedDate != null
                && (criteria.EstimatedCompletedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.EstimatedCompletedDate <= criteria.EstimatedCompletedDate.DateTo);
            }

            if (criteria.EstimatedDuration != null)
            {
                query = query.Where(row => row.EstimatedDuration == criteria.EstimatedDuration);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
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
                && (criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date))
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
                && (criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date))
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
