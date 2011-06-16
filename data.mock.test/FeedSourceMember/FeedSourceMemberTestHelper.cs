using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Data;
using Epiworx.Test.Helpers;

namespace Epiworx.Test.Helpers
{
    public class FeedSourceTestHelper
    {
        public List<FeedSourceMemberData> FeedSources = new List<FeedSourceMemberData>();

        public FeedSourceMemberData[] Fetch(Feed parent)
        {
            var query = this.FeedSources.AsQueryable();

            query = query.Where(row => row.FeedId == parent.FeedId);

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public FeedSourceMemberData Update(FeedSourceMemberData data, FeedData parent)
        {
            var feedSource = this.FeedSources.Where(row => row.FeedId == data.FeedId
                   && row.SourceId == data.SourceId).Single();

            Csla.Data.DataMapper.Map(data, feedSource);

            return data;
        }

        public FeedSourceMemberData Insert(FeedSourceMemberData data, FeedData parent)
        {
            data.FeedId = parent.FeedId;

            this.FeedSources.Add(data);

            return data;
        }

        public void Delete(FeedSourceMemberData data)
        {
            var feedSource = this.FeedSources.Where(row => row.FeedId == data.FeedId
                  && row.SourceId == data.SourceId).First();

            this.FeedSources.Remove(feedSource);
        }
    }
}

