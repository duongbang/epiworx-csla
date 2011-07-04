using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class TimelineDataFactory : ITimelineDataFactory
    {
        public TimelineData Fetch(TimelineDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var timeline = this.Fetch(ctx, criteria)
                    .Single();

                var timelineData = new TimelineData();

                this.Fetch(timeline, timelineData);

                return timelineData;
            }
        }

        public TimelineData[] FetchInfoList(TimelineDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var timelines = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var timelineDataList = new List<TimelineData>();

                foreach (var timeline in timelines)
                {
                    var timelineData = new TimelineData();

                    this.Fetch(timeline, timelineData);

                    timelineDataList.Add(timelineData);
                }

                return timelineDataList.ToArray();
            }
        }

        public TimelineData[] FetchLookupInfoList(TimelineDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var timelines = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var timelineDataList = new List<TimelineData>();

                foreach (var timeline in timelines)
                {
                    var timelineData = new TimelineData();

                    this.Fetch(timeline, timelineData);

                    timelineDataList.Add(timelineData);
                }

                return timelineDataList.ToArray();
            }
        }

        public TimelineData Create()
        {
            return new TimelineData();
        }

        public TimelineData Update(TimelineData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var timeline =
                    new Timeline
                    {
                        TimelineId = data.TimelineId
                    };

                ctx.ObjectContext.Timelines.Attach(timeline);

                DataMapper.Map(data, timeline);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public TimelineData Insert(TimelineData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var timeline = new Timeline();

                DataMapper.Map(data, timeline);

                ctx.ObjectContext.AddToTimelines(timeline);

                ctx.ObjectContext.SaveChanges();

                data.TimelineId = timeline.TimelineId;

                return data;
            }
        }

        public void Delete(TimelineDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var timeline = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Timelines.DeleteObject(timeline);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Timeline timeline, TimelineData timelineData)
        {
            DataMapper.Map(timeline, timelineData);

            timelineData.Source = new SourceData();
            DataMapper.Map(timeline.Source, timelineData.Source);

            timelineData.CreatedByUser = new UserData();
            DataMapper.Map(timeline.CreatedByUser, timelineData.CreatedByUser);

            timelineData.ModifiedByUser = new UserData();
            DataMapper.Map(timeline.ModifiedByUser, timelineData.ModifiedByUser);
        }

        private IQueryable<Timeline> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             TimelineDataCriteria criteria)
        {
            IQueryable<Timeline> query = ctx.ObjectContext.Timelines
                .Include("Source")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.TimelineId != null)
            {
                query = query.Where(row => row.TimelineId == criteria.TimelineId);
            }

            if (criteria.Body != null)
            {
                query = query.Where(row => row.Body == criteria.Body);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.SourceId != null)
            {
                query = query.Where(row => criteria.SourceId.Contains(row.SourceId));
            }

            if (criteria.SourceTypeId != null)
            {
                query = query.Where(row => row.SourceTypeId == criteria.SourceTypeId);
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
                query = query.Where(row => row.Body.Contains(criteria.Text));
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
