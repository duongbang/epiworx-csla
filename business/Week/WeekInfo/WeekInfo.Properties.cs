using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class WeekInfo
    {
        private static Csla.PropertyInfo<int> WeekIdProperty =
            RegisterProperty<int>(row => row.WeekId, "WeekId");
        public int WeekId
        {
            get { return this.GetProperty(WeekIdProperty); }
            set { this.LoadProperty(WeekIdProperty, value); }
        }
            
        private static Csla.PropertyInfo<DateTime> EndDateProperty =
            RegisterProperty<DateTime>(row => row.EndDate, "EndDate");
        public DateTime EndDate
        {
            get { return this.GetProperty(EndDateProperty); }
            set { this.LoadProperty(EndDateProperty, value); }
        }
            
        private static Csla.PropertyInfo<int> PeriodProperty =
            RegisterProperty<int>(row => row.Period, "Period");
        public int Period
        {
            get { return this.GetProperty(PeriodProperty); }
            set { this.LoadProperty(PeriodProperty, value); }
        }
            
        private static Csla.PropertyInfo<DateTime> StartDateProperty =
            RegisterProperty<DateTime>(row => row.StartDate, "StartDate");
        public DateTime StartDate
        {
            get { return this.GetProperty(StartDateProperty); }
            set { this.LoadProperty(StartDateProperty, value); }
        }
            
        private static Csla.PropertyInfo<int> YearProperty =
            RegisterProperty<int>(row => row.Year, "Year");
        public int Year
        {
            get { return this.GetProperty(YearProperty); }
            set { this.LoadProperty(YearProperty, value); }
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
