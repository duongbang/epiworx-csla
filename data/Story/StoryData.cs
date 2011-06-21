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
        public DateTime CompletedDate { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public DateTime EstimatedCompletedDate { get; set; }
        public decimal EstimatedDuration { get; set; }
        public bool IsArchived { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
        public ProjectData Project { get; set; }
        public int SprintId { get; set; }
        public SprintData Sprint { get; set; }
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
            this.StoryId = 0;
            this.AssignedTo = 0;
            this.AssignedToUser = new UserData();
            this.AssignedDate = DateTime.MaxValue;
            this.CompletedDate = DateTime.MaxValue;
            this.Description = string.Empty;
            this.Duration = 0;
            this.EstimatedCompletedDate = DateTime.MaxValue;
            this.EstimatedDuration = 0;
            this.IsArchived = false;
            this.ProjectId = 0;
            this.Project = new ProjectData();
            this.SprintId = 0;
            this.Sprint = new SprintData();
            this.StartDate = DateTime.MaxValue;
            this.StatusId = 0;
            this.Status = new StatusData();
            this.ModifiedBy = 0;
            this.ModifiedByUser = new UserData();
            this.ModifiedDate = DateTime.MaxValue;
            this.CreatedBy = 0;
            this.CreatedByUser = new UserData();
            this.CreatedDate = DateTime.MaxValue;
        }
    }
}
