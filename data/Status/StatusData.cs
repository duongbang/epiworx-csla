using System;
using System.Collections.Generic;

namespace Epiworx.Data
{
    [Serializable]
    public class StatusData
    {
        public int StatusId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsStarted { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public ProjectData Project { get; set; }
        public int Ordinal { get; set; }
        public int CreatedBy { get; set; }
        public UserData CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public UserData ModifiedByUser { get; set; }
        public DateTime ModifiedDate { get; set; }

        public StatusData()
        {
        }
    }
}
