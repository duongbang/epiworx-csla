using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class UserDataCriteria : Csla.CriteriaBase<UserDataCriteria>, IDataCriteria
    {
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsArchived { get; set; }
        public string Name { get; set; }
        public int[] ProjectId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateRangeCriteria TokenExpirationDate { get; set; }
        public DateRangeCriteria CreatedDate { get; set; }
        public DateRangeCriteria ModifiedDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public UserDataCriteria()
        {
            this.SortBy = "FullName";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
