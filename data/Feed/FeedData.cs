using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class FeedData
    {
        public int FeedId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int SourceId { get; set; }
        public SourceData Source { get; set; }
        public int SourceTypeId { get; set; }
        public SourceTypeData SourceType { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<FeedSourceMemberData> Sources { get; set; }

        public FeedData()
        {
            this.Sources = new List<FeedSourceMemberData>();
        }
    }
}
