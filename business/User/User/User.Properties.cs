using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class User
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
        public string Email
        {
            get { return this.GetProperty(EmailProperty); }
            set { this.SetProperty(EmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> FullNameProperty =
            RegisterProperty<string>(row => row.FullName, "FullName");
        public string FullName
        {
            get { return this.GetProperty(FullNameProperty); }
            set { this.SetProperty(FullNameProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsActiveProperty =
            RegisterProperty<bool>(row => row.IsActive, "IsActive");
        public bool IsActive
        {
            get { return this.GetProperty(IsActiveProperty); }
            set { this.SetProperty(IsActiveProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.SetProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<string> PasswordProperty =
            RegisterProperty<string>(row => row.Password, "Password");
        public string Password
        {
            get { return this.GetProperty(PasswordProperty); }
            private set { this.SetProperty(PasswordProperty, value); }
        }

        private static Csla.PropertyInfo<string> SaltProperty =
            RegisterProperty<string>(row => row.Salt, "Salt");
        public string Salt
        {
            get { return this.GetProperty(SaltProperty); }
            private set { this.SetProperty(SaltProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            private set { this.SetProperty(CreatedDateProperty, value); }
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
