using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Sprint
    {
        private static Csla.PropertyInfo<int> SprintIdProperty =
            RegisterProperty<int>(row => row.SprintId, "SprintId");
        [DataObjectField(true, false)]
        public int SprintId
        {
            get { return this.GetProperty(SprintIdProperty); }
            private set { this.SetProperty(SprintIdProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CompletedDateProperty =
            RegisterProperty<DateTime>(row => row.CompletedDate, "CompletedDate");
        public DateTime CompletedDate
        {
            get { return this.GetProperty(CompletedDateProperty); }
            set { this.SetProperty(CompletedDateProperty, value); }
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

        private static Csla.PropertyInfo<bool> IsCompletedProperty =
            RegisterProperty<bool>(row => row.IsCompleted, "IsCompleted");
        public bool IsCompleted
        {
            get { return this.GetProperty(IsCompletedProperty); }
            set { this.SetProperty(IsCompletedProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> DurationProperty =
            RegisterProperty<decimal>(row => row.Duration, "Duration");
        public decimal Duration
        {
            get { return this.GetProperty(DurationProperty); }
            set { this.SetProperty(DurationProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> EstimatedCompletedDateProperty =
            RegisterProperty<DateTime>(row => row.EstimatedCompletedDate, "EstimatedCompletedDate");
        public DateTime EstimatedCompletedDate
        {
            get { return this.GetProperty(EstimatedCompletedDateProperty); }
            set { this.SetProperty(EstimatedCompletedDateProperty, value); }
        }

        private static Csla.PropertyInfo<decimal> EstimatedDurationProperty =
            RegisterProperty<decimal>(row => row.EstimatedDuration, "EstimatedDuration");
        public decimal EstimatedDuration
        {
            get { return this.GetProperty(EstimatedDurationProperty); }
            set { this.SetProperty(EstimatedDurationProperty, value); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<int> ProjectIdProperty =
            RegisterProperty<int>(row => row.ProjectId, "ProjectId");
        public int ProjectId
        {
            get { return this.GetProperty(ProjectIdProperty); }
            private set { this.SetProperty(ProjectIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ProjectNameProperty =
            RegisterProperty<string>(row => row.ProjectName, "ProjectName");
        public string ProjectName
        {
            get { return this.GetProperty(ProjectNameProperty); }
            private set { this.SetProperty(ProjectNameProperty, value); }
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
