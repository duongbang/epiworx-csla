using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class FeedService
    {
        public static Feed FeedFetch(int feedId)
        {
            return Feed.FetchFeed(
                new FeedDataCriteria
                {
                    FeedId = feedId
                });
        }

        public static FeedInfoList FeedFetchInfoList(int maximumRecords)
        {
            return FeedService.FeedFetchInfoList(
                new FeedDataCriteria
                    {
                        SortBy = "CreatedDate",
                        SortOrder = ListSortDirection.Descending,
                        MaximumRecords = maximumRecords
                    });
        }

        public static FeedInfoList FeedFetchInfoList(DateTime createdDateFrom, DateTime createdDateTo, int maximumRecords)
        {
            return FeedService.FeedFetchInfoList(
                new FeedDataCriteria
                {
                    CreatedDate = new DateRangeCriteria(createdDateFrom, createdDateTo),
                    SortBy = "CreatedDate",
                    SortOrder = ListSortDirection.Descending,
                    MaximumRecords = maximumRecords
                });
        }

        public static FeedInfoList FeedFetchInfoList(FeedDataCriteria criteria)
        {
            return FeedInfoList.FetchFeedInfoList(criteria);
        }

        //internal static void FeedAdd(string action, Customer customer)
        //{
        //    var feed = FeedService.FeedNew(action, customer);

        //    feed.Save();
        //}

        public static Feed FeedSave(Feed feed)
        {
            if (!feed.IsValid)
            {
                return feed;
            }

            Feed result;

            if (feed.IsNew)
            {
                result = FeedService.FeedInsert(feed);
            }
            else
            {
                result = FeedService.FeedUpdate(feed);
            }

            return result;
        }

        public static Feed FeedInsert(Feed feed)
        {
            feed = feed.Save();

            return feed;
        }

        public static Feed FeedUpdate(Feed feed)
        {
            feed = feed.Save();

            return feed;
        }

        public static Feed FeedNew()
        {
            var feed = Feed.NewFeed();

            return feed;
        }

        public static Feed FeedNew(string action, ISource source)
        {
            var feed = Feed.NewFeed();

            feed.Action = action;

            feed.Sources.Add(source);

            return feed;
        }
    }
}
