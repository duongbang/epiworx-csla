using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserPassword
    {
        private static Csla.PropertyInfo<int> UserIdProperty =
            RegisterProperty<int>(row => row.UserId, "UserId");
        [DataObjectField(true, false)]
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
            private set { this.SetProperty(UserIdProperty, value); }
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

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            private set { this.SetProperty(ModifiedDateProperty, value); }
        }
    }
}
