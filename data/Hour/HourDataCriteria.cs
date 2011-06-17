using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class HourDataCriteria : Csla.CriteriaBase<HourDataCriteria>, IDataCriteria
    {
        public int? HourId { get; set; }
        public DateRangeCriteria Date { get; set; }
        public decimal? Duration { get; set; }
        public bool? IsArchived { get; set; }
        public string Notes { get; set; }
        public int? StoryId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public HourDataCriteria()
        {
            this.SortBy = null;
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
