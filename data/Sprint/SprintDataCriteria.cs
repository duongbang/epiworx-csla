using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class SprintDataCriteria : Csla.CriteriaBase<SprintDataCriteria>, IDataCriteria
    {
        public int? SprintId { get; set; }
        public DateRangeCriteria CompletedDate { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsCompleted { get; set; }
        public decimal? Duration { get; set; }
        public DateRangeCriteria EstimatedCompletedDate { get; set; }
        public decimal? EstimatedDuration { get; set; }
        public string Name { get; set; }
        public int[] ProjectId { get; set; }
        public int? CreatedBy { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public SprintDataCriteria()
        {
            this.SortBy = "Name";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
