using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class FeedDataCriteria : Csla.CriteriaBase<FeedDataCriteria>, IDataCriteria
    {
        public int? FeedId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int? SourceId { get; set; }
        public int? SourceTypeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public FeedDataCriteria()
        {
            this.SortBy = "CreatedDate";
            this.SortOrder = ListSortDirection.Descending;
        }
    }
}
