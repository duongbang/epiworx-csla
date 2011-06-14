using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class FeedDataFactory : IFeedDataFactory
    {
        public FeedData Fetch(FeedDataCriteria criteria)
        {
            var data = MockDb.Feeds
                .Where(row => row.FeedId == criteria.FeedId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public FeedData Fetch(FeedData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .SingleOrDefault();

            return data;
        }

        public FeedData[] FetchInfoList(FeedDataCriteria criteria)
        {
            var query = MockDb.Feeds
                .AsQueryable();

            var feeds = query.AsQueryable();

            var data = new List<FeedData>();

            foreach (var feed in feeds)
            {
                data.Add(this.Fetch(feed));
            }

            return data.ToArray();
        }

        public FeedData Create()
        {
            return new FeedData();
        }

        public FeedData Update(FeedData data)
        {
            var feed = MockDb.Feeds
                .Where(row => row.FeedId == data.FeedId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, feed);

            return data;
        }

        public FeedData Insert(FeedData data)
        {
            if (MockDb.Feeds.Count() == 0)
            {
                data.FeedId = 1;
            }
            else
            {
                data.FeedId = MockDb.Feeds.Select(row => row.FeedId).Max() + 1;
            }

            MockDb.Feeds.Add(data);

            return data;
        }

        public void Delete(FeedDataCriteria criteria)
        {
            var data = MockDb.Feeds
                .Where(row => row.FeedId == criteria.FeedId)
                .SingleOrDefault();

            MockDb.Feeds.Remove(data);
        }
    }
}
