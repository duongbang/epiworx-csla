using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class OrganizationUserInfo
    {
        private static Csla.PropertyInfo<int> OrganizationUserMemberIdProperty =
            RegisterProperty<int>(row => row.OrganizationUserMemberId, "OrganizationUserMemberId");
        public int OrganizationUserMemberId
        {
            get { return this.GetProperty(OrganizationUserMemberIdProperty); }
            set { this.LoadProperty(OrganizationUserMemberIdProperty, value); }
        }

        private static Csla.PropertyInfo<int> OrganizationIdProperty =
            RegisterProperty<int>(row => row.OrganizationId, "OrganizationId");
        public int OrganizationId
        {
            get { return this.GetProperty(OrganizationIdProperty); }
            set { this.LoadProperty(OrganizationIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> OrganizationNameProperty =
            RegisterProperty<string>(row => row.OrganizationName, "OrganizationName");
        public string OrganizationName
        {
            get { return this.GetProperty(OrganizationNameProperty); }
            set { this.LoadProperty(OrganizationNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> RoleIdProperty =
            RegisterProperty<int>(row => row.RoleId, "RoleId");
        public int RoleId
        {
            get { return this.GetProperty(RoleIdProperty); }
            set { this.LoadProperty(RoleIdProperty, value); }
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
            set { this.LoadProperty(UserIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> UserEmailProperty =
            RegisterProperty<string>(row => row.UserEmail, "UserEmail");
        public string UserEmail
        {
            get { return this.GetProperty(UserEmailProperty); }
            set { this.LoadProperty(UserEmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> UserNameProperty =
            RegisterProperty<string>(row => row.UserName, "UserName");
        public string UserName
        {
            get { return this.GetProperty(UserNameProperty); }
            set { this.LoadProperty(UserNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            set { this.LoadProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            set { this.LoadProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            set { this.LoadProperty(CreatedDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            set { this.LoadProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            set { this.LoadProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            set { this.LoadProperty(ModifiedDateProperty, value); }
        }
    }
}
