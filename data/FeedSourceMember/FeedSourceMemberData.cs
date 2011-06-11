using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class FeedSourceMemberData
    {
        public int FeedSourceMemberId { get; set; }
        public int FeedId { get; set; }
        public int SourceId { get; set; }
        public SourceData Source { get; set; }
        public int SourceTypeId { get; set; }
        public SourceTypeData SourceType { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }


        public FeedSourceMemberData()
        {
        }
    }
}
