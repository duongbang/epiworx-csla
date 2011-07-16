using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WcfRestService
{
    public class FeedData
    {
        public int FeedId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public SourceData Source { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<FeedSourceData> Sources { get; set; }

        public FeedData()
        {
            this.Sources = new List<FeedSourceData>();
        }

        public FeedData(FeedInfo feed)
            : this()
        {
            this.FeedId = feed.FeedId;
            this.Action = feed.Action;
            this.Description = feed.Description;
            this.Source = new SourceData(feed.SourceId, feed.SourceTypeName, feed.SourceName);
            this.CreatedBy = new UserData(feed.CreatedBy, feed.CreatedByName, feed.CreatedByEmail);
            this.CreatedDate = feed.CreatedDate;

            foreach (var source in feed.Sources)
            {
                this.Sources.Add(new FeedSourceData(source));
            }
        }
    }
}