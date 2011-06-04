using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class SourceTypeDataCriteria : Csla.CriteriaBase<SourceTypeDataCriteria>, IDataCriteria
    {
		public int? SourceTypeId { get; set; }
		public string Name { get; set; }
		public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public SourceTypeDataCriteria()
        {
            this.SortBy = "Name";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
