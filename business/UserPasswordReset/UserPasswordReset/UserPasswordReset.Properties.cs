using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserPasswordReset
    {
        private static Csla.PropertyInfo<int> UserIdProperty =
             RegisterProperty<int>(row => row.UserId, "UserId");
        [DataObjectField(true, false)]
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
            private set { this.SetProperty(UserIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> EmailProperty =
            RegisterProperty<string>(row => row.Email, "Email");
        [DataObjectField(true, false)]
        public string Email
        {
            get { return this.GetProperty(EmailProperty); }
            private set { this.SetProperty(EmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> PasswordProperty =
            RegisterProperty<string>(row => row.Password, "Password");
        public string Password
        {
            get { return this.GetProperty(PasswordProperty); }
            set { this.SetProperty(PasswordProperty, value); }
        }

        private static Csla.PropertyInfo<string> PasswordConfirmationProperty =
            RegisterProperty<string>(row => row.PasswordConfirmation, "PasswordConfirmation");
        public string PasswordConfirmation
        {
            get { return this.GetProperty(PasswordConfirmationProperty); }
            set { this.SetProperty(PasswordConfirmationProperty, value); }
        }

        private static Csla.PropertyInfo<string> TokenProperty =
            RegisterProperty<string>(row => row.Token, "Token");
        public string Token
        {
            get { return this.GetProperty(TokenProperty); }
            private set { this.SetProperty(TokenProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> TokenExpirationDateProperty =
            RegisterProperty<DateTime>(row => row.TokenExpirationDate, "TokenExpirationDate");
        public DateTime TokenExpirationDate
        {
            get { return this.GetProperty(TokenExpirationDateProperty); }
            private set { this.SetProperty(TokenExpirationDateProperty, value); }
        }
    }
}
