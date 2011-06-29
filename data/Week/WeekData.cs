using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class WeekData
    {
		public int WeekId { get; set; }
		public DateTime EndDate { get; set; }
		public int Period { get; set; }
		public DateTime StartDate { get; set; }
		public int Year { get; set; }
		public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }

        public WeekData()
        {
		    this.WeekId = 0;
		    this.EndDate = DateTime.MaxValue;
		    this.Period = 0;
		    this.StartDate = DateTime.MaxValue;
		    this.Year = 0;
		    this.CreatedBy = 0;
            this.CreatedByUser = new UserData();
		    this.CreatedDate = DateTime.MaxValue;
		    this.ModifiedBy = 0;
            this.ModifiedByUser = new UserData();
		    this.ModifiedDate = DateTime.MaxValue;
        }
    }
}
