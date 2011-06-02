using System;
using System.ComponentModel;

namespace Epiworx.Data
{
    [Serializable]
    public class UserPasswordResetDataCriteria : Csla.CriteriaBase<UserPasswordResetDataCriteria>, IDataCriteria
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public string Text { get; set; }
        public int? SkipRecords { get; set; }
        public int? MaximumRecords { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortOrder { get; set; }

        public UserPasswordResetDataCriteria()
        {
            this.SortBy = "Token";
            this.SortOrder = ListSortDirection.Ascending;
        }
    }
}
