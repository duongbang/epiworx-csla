using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class UserPasswordDataCriteria : Csla.CriteriaBase<UserPasswordDataCriteria>, IDataCriteria
    {
        public int? UserId { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public UserPasswordDataCriteria()
        {
            this.SortBy = "UserId";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
