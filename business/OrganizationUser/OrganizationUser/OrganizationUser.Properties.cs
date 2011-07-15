using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;


namespace Epiworx.Business
{
    public partial class OrganizationUser
    {
        private static Csla.PropertyInfo<int> OrganizationUserMemberIdProperty =
            RegisterProperty<int>(row => row.OrganizationUserMemberId, "OrganizationUserMemberId");
        [DataObjectField(true, false)]
        public int OrganizationUserMemberId
        {
            get { return this.GetProperty(OrganizationUserMemberIdProperty); }
            private set { this.SetProperty(OrganizationUserMemberIdProperty, value); }
        }

        private static Csla.PropertyInfo<int> OrganizationIdProperty =
            RegisterProperty<int>(row => row.OrganizationId, "OrganizationId");
        public int OrganizationId
        {
            get { return this.GetProperty(OrganizationIdProperty); }
            private set { this.SetProperty(OrganizationIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> OrganizationNameProperty =
            RegisterProperty<string>(row => row.OrganizationName, "OrganizationName");
        public string OrganizationName
        {
            get { return this.GetProperty(OrganizationNameProperty); }
            private set { this.SetProperty(OrganizationNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> RoleIdProperty =
            RegisterProperty<int>(row => row.RoleId, "RoleId");
        public int RoleId
        {
            get { return this.GetProperty(RoleIdProperty); }
            set { this.SetProperty(RoleIdProperty, value); }
        }

        public string RoleName
        {
            get { return DataHelper.FetchRoleName(this.RoleId); }
        }

        private static Csla.PropertyInfo<int> UserIdProperty =
            RegisterProperty<int>(row => row.UserId, "UserId");
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
            private set { this.SetProperty(UserIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> UserEmailProperty =
            RegisterProperty<string>(row => row.UserEmail, "UserEmail");
        public string UserEmail
        {
            get { return this.GetProperty(UserEmailProperty); }
            private set { this.SetProperty(UserEmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> UserNameProperty =
            RegisterProperty<string>(row => row.UserName, "UserName");
        public string UserName
        {
            get { return this.GetProperty(UserNameProperty); }
            private set { this.SetProperty(UserNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            private set { this.SetProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            private set { this.SetProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            private set { this.SetProperty(CreatedDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            private set { this.SetProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            private set { this.SetProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            private set { this.SetProperty(ModifiedDateProperty, value); }
        }

        // public static Csla.PropertyInfo<ChildPropertyType> ChildPropertyProperty =
        //     RegisterProperty<ChildPropertyType>(row => row.ChildProperty);
        // public ChildPropertyType ChildProperty
        // {
        //     get { return GetProperty(ChildPropertyProperty); }
        //     private set { LoadProperty(ChildPropertyProperty, value); }
        // }
    }
}
