using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Hour
    {
        private static Csla.PropertyInfo<int> HourIdProperty =
            RegisterProperty<int>(row => row.HourId, "HourId");
        [DataObjectField(true, false)]
        public int HourId
        {
            get { return this.GetProperty(HourIdProperty); }
            private set { this.SetProperty(HourIdProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> DateProperty =
            RegisterProperty<DateTime>(row => row.Date, "Date");
        public DateTime Date
        {
            get { return this.GetProperty(DateProperty); }
            set { this.SetProperty(DateProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> DurationProperty =
            RegisterProperty<decimal>(row => row.Duration, "Duration");
        public decimal Duration
        {
            get { return this.GetProperty(DurationProperty); }
            set { this.SetProperty(DurationProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.SetProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NotesProperty =
            RegisterProperty<string>(row => row.Notes, "Notes");
        public string Notes
        {
            get { return this.GetProperty(NotesProperty); }
            set { this.SetProperty(NotesProperty, value); }
        }

        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "ProjectId");
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            internal set { this.SetProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.GetProperty(ProjectNameProperty); }
            internal set { this.SetProperty(ProjectNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> SprintIdProperty =
            RegisterProperty<int>(row => row.SprintId, "SprintId");
        public int SprintId
        {
            get { return this.GetProperty(SprintIdProperty); }
            internal set { this.SetProperty(SprintIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> SprintNameProperty =
            RegisterProperty<string>(row => row.SprintName, "SprintName");
        public string SprintName
        {
            get { return this.GetProperty(SprintNameProperty); }
            internal set { this.SetProperty(SprintNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> StoryIdProperty =
            RegisterProperty<int>(row => row.StoryId, "StoryId");
        public int StoryId
        {
            get { return this.GetProperty(StoryIdProperty); }
            set { this.SetProperty(StoryIdProperty, value); }
        }

        private static Csla.PropertyInfo<int> UserIdProperty =
            RegisterProperty<int>(row => row.UserId, "UserId");
        public int UserId
        {
            get { return this.GetProperty(UserIdProperty); }
            set { this.SetProperty(UserIdProperty, value); }
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
