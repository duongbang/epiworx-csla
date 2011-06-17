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
        public static Feed FeedAdd()
        {
            var feed = FeedTestHelper.FeedNew();

            feed = FeedRepository.FeedSave(feed);

            return feed;
        }

        public static Feed FeedNew()
        {
            var feed = FeedRepository.FeedNew();

            feed.Action = DataHelper.RandomString(30);

            return feed;
        }
    }
}