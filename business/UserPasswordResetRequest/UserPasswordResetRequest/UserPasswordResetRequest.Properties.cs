using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserPasswordResetRequest
    {
        private static Csla.PropertyInfo<string> EmailProperty =
            RegisterProperty<string>(row => row.Email, "Email");
        [DataObjectField(true, false)]
        public string Email
        {
            get { return this.GetProperty(EmailProperty); }
            private set { this.SetProperty(EmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> TokenProperty =
            RegisterProperty<string>(row => row.Token, "Token");
        public string Token
        {
            get { return this.GetProperty(TokenProperty); }
            internal set { this.SetProperty(TokenProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> TokenExpirationDateProperty =
            RegisterProperty<DateTime>(row => row.TokenExpirationDate, "TokenExpirationDate");
        public DateTime TokenExpirationDate
        {
            get { return this.GetProperty(TokenExpirationDateProperty); }
            internal set { this.SetProperty(TokenExpirationDateProperty, value); }
        }

        private static Csla.PropertyInfo<bool> SuccessProperty =
            RegisterProperty<bool>(row => row.Success, "Success");
        public bool Success
        {
            get { return this.GetProperty(SuccessProperty); }
            private set { this.SetProperty(SuccessProperty, value); }
        }
    }
}
