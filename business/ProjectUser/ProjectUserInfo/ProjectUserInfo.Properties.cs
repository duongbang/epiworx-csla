using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class ProjectUserInfo
    {
        private static Csla.PropertyInfo<int> ProjectUserMemberIdProperty =
            RegisterProperty<int>(row => row.ProjectUserMemberId, "ProjectUserMemberId");
        public int ProjectUserMemberId
        {
            get { return this.GetProperty(ProjectUserMemberIdProperty); }
            set { this.LoadProperty(ProjectUserMemberIdProperty, value); }
        }

        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "ProjectId");
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            set { this.LoadProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.GetProperty(ProjectNameProperty); }
            set { this.LoadProperty(ProjectNameProperty, value); }
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
