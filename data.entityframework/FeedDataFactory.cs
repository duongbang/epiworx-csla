using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class FeedDataFactory : IFeedDataFactory
    {
        public FeedData Fetch(FeedDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var feed = this.Fetch(ctx, criteria)
                   .Single();

                var feedData = new FeedData();

                this.Fetch(feed, feedData);

                return feedData;
            }
        }

        public FeedData[] FetchInfoList(FeedDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var feeds = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var feedDataList = new List<FeedData>();

                foreach (var feed in feeds)
                {
                    var feedData = new FeedData();

                    this.Fetch(feed, feedData);

                    feedDataList.Add(feedData);
                }

                return feedDataList.ToArray();
            }
        }

        public FeedData[] FetchLookupInfoList(FeedDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var feeds = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var feedDataList = new List<FeedData>();

                foreach (var feed in feeds)
                {
                    var feedData = new FeedData();

                    this.Fetch(feed, feedData);

                    feedDataList.Add(feedData);
                }

                return feedDataList.ToArray();
            }
        }

        public FeedData Create()
        {
            return new FeedData();
        }

        public FeedData Update(FeedData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var feed =
                    new Feed
                    {
                        FeedId = data.FeedId
                    };

                ctx.ObjectContext.Feeds.Attach(feed);

                DataMapper.Map(data, feed);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public FeedData Insert(FeedData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var feed = new Feed();

                DataMapper.Map(data, feed);

                ctx.ObjectContext.AddToFeeds(feed);

                ctx.ObjectContext.SaveChanges();

                data.FeedId = feed.FeedId;

                return data;
            }
        }

        public void Delete(FeedDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var feed = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Feeds.DeleteObject(feed);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Feed feed, FeedData feedData)
        {
            DataMapper.Map(feed, feedData);

            feedData.Source = new SourceData();
            DataMapper.Map(feed.Source, feedData.Source);

            feedData.CreatedByUser = new UserData();
            DataMapper.Map(feed.CreatedByUser, feedData.CreatedByUser);

            foreach (var feedSourceMember in feed.FeedSourceMembers)
            {
                var feedSourceMemberData = new FeedSourceMemberData();
                DataMapper.Map(feedSourceMember, feedSourceMemberData);

                var sourceData = new SourceData();
                DataMapper.Map(feedSourceMember.Source, sourceData);
                feedSourceMemberData.Source = sourceData;

                feedData.Sources.Add(feedSourceMemberData);
            }
        }

        private IQueryable<Feed> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             FeedDataCriteria criteria)
        {
            IQueryable<Feed> query = ctx.ObjectContext.Feeds
                .Include("Source")
                .Include("FeedSourceMembers")
                .Include("FeedSourceMembers.Source")
                .Include("CreatedByUser");

            if (criteria.FeedId != null)
            {
                query = query.Where(row => row.FeedId == criteria.FeedId);
            }

            if (criteria.FeedId != null)
            {
                query = query.Where(row => row.FeedId == criteria.FeedId);
            }

            if (criteria.Action != null)
            {
                query = query.Where(row => row.Action == criteria.Action);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate != null && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null && criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
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