using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class FeedSourceMemberDataCriteria : Csla.CriteriaBase<FeedSourceMemberDataCriteria>, IDataCriteria
    {
        public int? FeedSourceMemberId { get; set; }
        public int? FeedId { get; set; }
        public int? SourceId { get; set; }
        public int? SourceTypeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public FeedSourceMemberDataCriteria()
        {
            this.SortBy = null;
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
