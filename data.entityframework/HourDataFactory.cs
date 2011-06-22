using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class HourDataFactory : IHourDataFactory
    {
        public HourData Fetch(HourDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var hour = this.Fetch(ctx, criteria)
                    .Single();

                var hourData = new HourData();

                this.Fetch(hour, hourData);

                return hourData;
            }
        }

        public HourData[] FetchInfoList(HourDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var hours = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var hourDataList = new List<HourData>();

                foreach (var hour in hours)
                {
                    var hourData = new HourData();

                    this.Fetch(hour, hourData);

                    hourDataList.Add(hourData);
                }

                return hourDataList.ToArray();
            }
        }

        public HourData[] FetchLookupInfoList(HourDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var hours = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var hourDataList = new List<HourData>();

                foreach (var hour in hours)
                {
                    var hourData = new HourData();

                    this.Fetch(hour, hourData);

                    hourDataList.Add(hourData);
                }

                return hourDataList.ToArray();
            }
        }

        public HourData Create()
        {
            return new HourData();
        }

        public HourData Update(HourData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var hour =
                    new Hour
                    {
                        HourId = data.HourId
                    };

                ctx.ObjectContext.Hours.Attach(hour);

                DataMapper.Map(data, hour);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public HourData Insert(HourData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var hour = new Hour();

                DataMapper.Map(data, hour);

                ctx.ObjectContext.AddToHours(hour);

                ctx.ObjectContext.SaveChanges();

                data.HourId = hour.HourId;

                return data;
            }
        }

        public void Delete(HourDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var hour = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Hours.DeleteObject(hour);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Hour hour, HourData hourData)
        {
            DataMapper.Map(hour, hourData);

            hourData.Project = new ProjectData();
            DataMapper.Map(hour.Story.Project, hourData.Project);

            hourData.Sprint = new SprintData();
            if (hourData.SprintId != 0)
            {
                DataMapper.Map(hour.Story.Sprint, hourData.Sprint);
            }

            hourData.Story = new StoryData();
            DataMapper.Map(hour.Story, hourData.Story);

            hourData.User = new UserData();
            DataMapper.Map(hour.User, hourData.User);

            hourData.CreatedByUser = new UserData();
            DataMapper.Map(hour.CreatedByUser, hourData.CreatedByUser);

            hourData.ModifiedByUser = new UserData();
            DataMapper.Map(hour.ModifiedByUser, hourData.ModifiedByUser);
        }

        private IQueryable<Hour> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             HourDataCriteria criteria)
        {
            IQueryable<Hour> query = ctx.ObjectContext.Hours
                .Include("Story")
                .Include("Story.Project")
                .Include("Story.Sprint")
                .Include("User")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.HourId != null)
            {
                query = query.Where(row => row.HourId == criteria.HourId);
            }

            if (criteria.Date != null
                && criteria.Date.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.Date >= criteria.Date.DateFrom);
            }

            if (criteria.Date != null
                && (criteria.Date.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.Date <= criteria.Date.DateTo);
            }

            if (criteria.Duration != null)
            {
                query = query.Where(row => row.Duration == criteria.Duration);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.Notes != null)
            {
                query = query.Where(row => row.Notes == criteria.Notes);
            }

            if (criteria.ProjectId != null)
            {
                query = query.Where(row => row.Story.ProjectId == criteria.ProjectId);
            }

            if (criteria.SprintId != null)
            {
                query = query.Where(row => row.Story.SprintId == criteria.SprintId);
            }

            if (criteria.StoryId != null)
            {
                query = query.Where(row => row.StoryId == criteria.StoryId);
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
                query = query.Where(row => row.Notes.Contains(criteria.Text));
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
