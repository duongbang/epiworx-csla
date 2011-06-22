using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class HourInfo
    {
        private static Csla.PropertyInfo<int> HourIdProperty =
            RegisterProperty<int>(row => row.HourId, "HourId");
        public int HourId
        {
            get { return this.GetProperty(HourIdProperty); }
            set { this.LoadProperty(HourIdProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> DateProperty =
            RegisterProperty<DateTime>(row => row.Date, "Date");
        public DateTime Date
        {
            get { return this.GetProperty(DateProperty); }
            set { this.LoadProperty(DateProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> DurationProperty =
            RegisterProperty<decimal>(row => row.Duration, "Duration");
        public decimal Duration
        {
            get { return this.GetProperty(DurationProperty); }
            set { this.LoadProperty(DurationProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.LoadProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NotesProperty =
            RegisterProperty<string>(row => row.Notes, "Notes");
        public string Notes
        {
            get { return this.GetProperty(NotesProperty); }
            set { this.LoadProperty(NotesProperty, value); }
        }

        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "ProjectId");
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            internal set { this.LoadProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.GetProperty(ProjectNameProperty); }
            internal set { this.LoadProperty(ProjectNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> SprintIdProperty =
            RegisterProperty<int>(row => row.SprintId, "SprintId");
        public int SprintId
        {
            get { return this.GetProperty(SprintIdProperty); }
            internal set { this.LoadProperty(SprintIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> SprintNameProperty =
            RegisterProperty<string>(row => row.SprintName, "SprintName");
        public string SprintName
        {
            get { return this.GetProperty(SprintNameProperty); }
            internal set { this.LoadProperty(SprintNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> StoryIdProperty =
            RegisterProperty<int>(row => row.StoryId, "StoryId");
        public int StoryId
        {
            get { return this.GetProperty(StoryIdProperty); }
            set { this.LoadProperty(StoryIdProperty, value); }
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
