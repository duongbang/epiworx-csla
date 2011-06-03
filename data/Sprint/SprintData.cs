using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class SprintData
    {
        public int SprintId { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
        public bool IsCompleted { get; set; }
        public decimal Duration { get; set; }
        public DateTime EstimatedCompletedDate { get; set; }
        public decimal EstimatedDuration { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public ProjectData Project { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }

        public SprintData()
        {
        }
    }
}
