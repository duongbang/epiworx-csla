using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;

namespace Epiworx.Business.Security
{
    public partial class BusinessIdentityProject
    {
        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "ProjectId");
        [DataObjectField(true, false)]
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            private set { this.LoadProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.GetProperty(ProjectNameProperty); }
            private set { this.LoadProperty(ProjectNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> RoleIdProperty =
            RegisterProperty<int>(row => row.RoleId, "RoleId");
        [DataObjectField(true, false)]
        public int RoleId
        {
            get { return this.GetProperty(RoleIdProperty); }
            private set { this.LoadProperty(RoleIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> RoleNameProperty =
            RegisterProperty<string>(row => row.RoleName, "RoleName");
        public string RoleName
        {
            get { return this.GetProperty(RoleNameProperty); }
            private set { this.LoadProperty(RoleNameProperty, value); }
        }
    }
}
