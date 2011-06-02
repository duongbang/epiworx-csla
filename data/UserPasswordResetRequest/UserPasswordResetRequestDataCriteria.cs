using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class UserPasswordResetRequestDataCriteria : Csla.CriteriaBase<UserPasswordResetRequestDataCriteria>, IDataCriteria
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public UserPasswordResetRequestDataCriteria()
        {
            this.SortBy = "Email";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
