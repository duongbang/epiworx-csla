using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WcfRestService
{
    public class FeedSourceData
    {
        public int FeedSourceMemberId { get; set; }
        public int FeedId { get; set; }
        public int SourceId { get; set; }
        public SourceData Source { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public FeedSourceData()
        {
        }

        public FeedSourceData(FeedSourceInfo feedSource)
            : this()
        {
            this.FeedSourceMemberId = feedSource.FeedId;
            this.FeedId = feedSource.FeedId;
            this.SourceId = feedSource.FeedId;
            this.Source = new SourceData(feedSource.SourceId, feedSource.SourceTypeName, feedSource.SourceName);
            this.CreatedBy = new UserData(feedSource.CreatedBy, string.Empty, string.Empty);
            this.CreatedDate = feedSource.CreatedDate;
        }
    }
}