using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class StoryDataCriteria : Csla.CriteriaBase<StoryDataCriteria>, IDataCriteria
    {
		public int? StoryId { get; set; }
		public int? AssignedTo { get; set; }
		public DateRangeCriteria AssignedDate { get; set; }
		public int? CategoryId { get; set; }
		public DateRangeCriteria CompletedDate { get; set; }
		public string Description { get; set; }
		public decimal? Duration { get; set; }
		public DateRangeCriteria EstimatedCompletedDate { get; set; }
		public decimal? EstimatedDuration { get; set; }
		public bool? IsArchived { get; set; }
		public int? ProjectId { get; set; }
		public int? SprintId { get; set; }
		public DateRangeCriteria StartDate { get; set; }
		public int? StatusId { get; set; }
		public int? ModifiedBy { get; set; }
		public DateRangeCriteria ModifiedDate { get; set; }
		public int? CreatedBy { get; set; }
		public DateRangeCriteria CreatedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public StoryDataCriteria()
        {
            this.SortBy = "Description";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
