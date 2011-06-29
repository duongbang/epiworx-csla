using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Week
    {
        private static Csla.PropertyInfo<int> WeekIdProperty =
            RegisterProperty<int>(row => row.WeekId, "WeekId");
        [DataObjectField(true, false)]
        public int WeekId
        {
            get { return this.GetProperty(WeekIdProperty); }
            private set { this.SetProperty(WeekIdProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> EndDateProperty =
            RegisterProperty<DateTime>(row => row.EndDate, "EndDate");
        public DateTime EndDate
        {
            get { return this.GetProperty(EndDateProperty); }
            set { this.SetProperty(EndDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> PeriodProperty =
            RegisterProperty<int>(row => row.Period, "Period");
        public int Period
        {
            get { return this.GetProperty(PeriodProperty); }
            set { this.SetProperty(PeriodProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> StartDateProperty =
            RegisterProperty<DateTime>(row => row.StartDate, "StartDate");
        public DateTime StartDate
        {
            get { return this.GetProperty(StartDateProperty); }
            set { this.SetProperty(StartDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> YearProperty =
            RegisterProperty<int>(row => row.Year, "Year");
        public int Year
        {
            get { return this.GetProperty(YearProperty); }
            set { this.SetProperty(YearProperty, value); }
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
