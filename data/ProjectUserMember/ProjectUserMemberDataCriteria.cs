using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class ProjectUserMemberDataCriteria : Csla.CriteriaBase<ProjectUserMemberDataCriteria>, IDataCriteria
    {
        public int? ProjectUserMemberId { get; set; }
        public int? ProjectId { get; set; }
        public int? RoleId { get; set; }
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

        public ProjectUserMemberDataCriteria()
        {
            this.SortBy = null;
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
