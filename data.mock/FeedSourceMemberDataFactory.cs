using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class FeedSourceMemberDataFactory : IFeedSourceMemberDataFactory
    {
        public FeedSourceMemberData[] Fetch(FeedData parentData)
        {
            var data = MockDb.FeedSourceMembers
                .Where(row => row.FeedId == parentData.FeedId);

            data = data.Select(this.Fetch);

            return data.ToArray();
        }

        public FeedSourceMemberData Fetch(FeedSourceMemberData data)
        {
            data.Source = MockDb.Sources
                .Where(row => row.SourceId == data.SourceId && row.SourceTypeId == data.SourceTypeId)
                .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            return data;
        }

        public FeedSourceMemberData[] FetchInfoList(FeedSourceMemberDataCriteria criteria)
        {
            var query = MockDb.FeedSourceMembers
                .AsQueryable();

            var feedSources = query.AsQueryable();

            var data = new List<FeedSourceMemberData>();

            foreach (var feedSource in feedSources)
            {
                data.Add(this.Fetch(feedSource));
            }

            return data.ToArray();
        }

        public FeedSourceMemberData[] FetchLookupInfoList(FeedSourceMemberDataCriteria criteria)
        {
            var query = MockDb.FeedSourceMembers
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public FeedSourceMemberData Create()
        {
            return new FeedSourceMemberData();
        }

        public FeedSourceMemberData Update(FeedSourceMemberData data)
        {
            var feedSource = MockDb.FeedSourceMembers
                .Where(row => row.SourceId == data.SourceId)
                .Single();

            Csla.Data.DataMapper.Map(data, feedSource);

            return data;
        }

        public FeedSourceMemberData Insert(FeedSourceMemberData data)
        {
            if (MockDb.FeedSourceMembers.Count() == 0)
            {
                data.FeedSourceMemberId = 1;
            }
            else
            {
                data.FeedSourceMemberId = MockDb.FeedSourceMembers.Select(row => row.FeedSourceMemberId).Max() + 1;
            }

            MockDb.FeedSourceMembers.Add(data);

            return data;
        }

        public void Delete(FeedSourceMemberDataCriteria criteria)
        {
            var data = MockDb.FeedSourceMembers
                .Where(row => row.SourceId == criteria.SourceId)
                .Single();

            MockDb.FeedSourceMembers.Remove(data);
        }
    }
}
