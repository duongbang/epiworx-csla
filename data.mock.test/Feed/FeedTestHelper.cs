using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Test.Helpers;

namespace Epiworx.Test.Helpers
{
    public class FeedTestHelper
    {
        public static Feed FeedAdd(SourceType sourceType, int sourceId)
        {
            var feed = FeedTestHelper.FeedNew(sourceType, sourceId);

            feed = FeedRepository.FeedSave(feed);

            return feed;
        }

        public static Feed FeedNew(SourceType sourceType, int sourceId)
        {
            var feed = FeedRepository.FeedNew();

            feed.Action = DataHelper.RandomString(30);
            feed.SourceTypeId = (int)sourceType;
            feed.SourceId = sourceId;

            return feed;
        }
    }
}