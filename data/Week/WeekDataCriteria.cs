using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class WeekDataCriteria : Csla.CriteriaBase<WeekDataCriteria>, IDataCriteria
    {
		public int? WeekId { get; set; }
		public DateRangeCriteria EndDate { get; set; }
		public int? Period { get; set; }
		public DateRangeCriteria StartDate { get; set; }
		public int? Year { get; set; }
		public int? CreatedBy { get; set; }
		public DateRangeCriteria CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateRangeCriteria ModifiedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public WeekDataCriteria()
        {
            this.SortBy = "StartDate";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
