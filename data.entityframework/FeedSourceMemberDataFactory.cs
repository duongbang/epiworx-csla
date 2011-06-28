using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class FeedSourceMemberDataFactory : IFeedSourceMemberDataFactory
    {
        public FeedSourceMemberData[] Fetch(FeedData parentData)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var feedSourceMembers = this.Fetch(ctx, new FeedSourceMemberDataCriteria { FeedId = parentData.FeedId })
                    .AsEnumerable();

                var feedSourceMemberDataList = new List<FeedSourceMemberData>();

                foreach (var feedSourceMember in feedSourceMembers)
                {
                    var feedSourceMemberData = new FeedSourceMemberData();

                    this.Fetch(feedSourceMember, feedSourceMemberData);

                    feedSourceMemberDataList.Add(feedSourceMemberData);
                }

                return feedSourceMemberDataList.ToArray();
            }
        }

        public FeedSourceMemberData Fetch(FeedSourceMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var feedSourceMember = this.Fetch(ctx, criteria)
                   .Single();

                var feedSourceMemberData = new FeedSourceMemberData();

                this.Fetch(feedSourceMember, feedSourceMemberData);

                return feedSourceMemberData;
            }
        }

        public FeedSourceMemberData[] FetchInfoList(FeedSourceMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var feedSourceMembers = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var feedSourceMemberDataList = new List<FeedSourceMemberData>();

                foreach (var feedSourceMember in feedSourceMembers)
                {
                    var feedSourceMemberData = new FeedSourceMemberData();

                    this.Fetch(feedSourceMember, feedSourceMemberData);

                    feedSourceMemberDataList.Add(feedSourceMemberData);
                }

                return feedSourceMemberDataList.ToArray();
            }
        }

        public FeedSourceMemberData Create()
        {
            return new FeedSourceMemberData();
        }

        public FeedSourceMemberData Update(FeedSourceMemberData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var feedSourceMember =
                    new FeedSourceMember
                    {
                        FeedSourceMemberId = data.FeedSourceMemberId
                    };

                ctx.ObjectContext.FeedSourceMembers.Attach(feedSourceMember);

                DataMapper.Map(data, feedSourceMember);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public FeedSourceMemberData Insert(FeedSourceMemberData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var feedSourceMember = new FeedSourceMember();

                DataMapper.Map(data, feedSourceMember);

                ctx.ObjectContext.AddToFeedSourceMembers(feedSourceMember);

                ctx.ObjectContext.SaveChanges();

                data.SourceId = feedSourceMember.SourceId;

                return data;
            }
        }

        public void Delete(FeedSourceMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var feedSourceMember = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.FeedSourceMembers.DeleteObject(feedSourceMember);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(FeedSourceMember feedSourceMember, FeedSourceMemberData feedSourceMemberData)
        {
            DataMapper.Map(feedSourceMember, feedSourceMemberData);

            feedSourceMemberData.CreatedByUser = new UserData();
            DataMapper.Map(feedSourceMember.CreatedByUser, feedSourceMemberData.CreatedByUser);
        }

        private IQueryable<FeedSourceMember> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             FeedSourceMemberDataCriteria criteria)
        {
            IQueryable<FeedSourceMember> query = ctx.ObjectContext.FeedSourceMembers
                .Include("Source")
                .Include("CreatedByUser");

            if (criteria.FeedSourceMemberId != null)
            {
                query = query.Where(row => row.FeedSourceMemberId == criteria.FeedSourceMemberId);
            }

            if (criteria.FeedId != null)
            {
                query = query.Where(row => row.FeedId == criteria.FeedId);
            }

            if (criteria.SourceId != null)
            {
                query = query.Where(row => row.SourceId == criteria.SourceId);
            }

            if (criteria.SourceTypeId != null)
            {
                query = query.Where(row => row.SourceTypeId == criteria.SourceTypeId);
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