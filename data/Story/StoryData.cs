using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class StoryData
    {
		public int StoryId { get; set; }
        public int AssignedTo { get; set; }
        public UserData AssignedToUser { get; set; }
		public DateTime AssignedDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryData Category { get; set; }
		public DateTime CompletedDate { get; set; }
		public string Description { get; set; }
		public decimal Duration { get; set; }
		public DateTime EstimatedCompletedDate { get; set; }
		public decimal EstimatedDuration { get; set; }
		public bool IsArchived { get; set; }
        public int ProjectId { get; set; }
        public ProjectData Project { get; set; }
        public int SprintId { get; set; }
        public SprintData Sprint{ get; set; }
		public DateTime StartDate { get; set; }
        public int StatusId { get; set; }
        public StatusData Status { get; set; }
		public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
		public DateTime CreatedDate { get; set; }

        public StoryData()
        {
        }
    }
}
