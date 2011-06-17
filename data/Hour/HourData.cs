using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class HourData
    {
        public int HourId { get; set; }
        public DateTime Date { get; set; }
        public decimal Duration { get; set; }
        public bool IsArchived { get; set; }
        public string Notes { get; set; }
        public int StoryId { get; set; }
        public StoryData Story { get; set; }
        public int UserId { get; set; }
        public UserData User { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }

        public HourData()
        {
            this.HourId = 0;
            this.Date = DateTime.MaxValue;
            this.Duration = 0;
            this.IsArchived = false;
            this.Notes = string.Empty;
            this.StoryId = 0;
            this.Story = new StoryData();
            this.UserId = 0;
            this.User = new UserData();
            this.CreatedBy = 0;
            this.CreatedByUser = new UserData();
            this.CreatedDate = DateTime.MaxValue;
            this.ModifiedBy = 0;
            this.ModifiedByUser = new UserData();
            this.ModifiedDate = DateTime.MaxValue;
        }
    }
}
