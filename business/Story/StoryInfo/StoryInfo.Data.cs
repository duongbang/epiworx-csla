using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class StoryInfo
    {
        private void Child_Fetch(StoryData data)
        {
            this.StoryId = data.StoryId;
            this.AssignedTo = data.AssignedTo;
            this.AssignedToName = data.AssignedToUser.Name;
            this.AssignedDate = data.AssignedDate;
            this.CompletedDate = data.CompletedDate;
            this.Description = data.Description;
            this.Duration = data.Duration;
            this.EstimatedCompletedDate = data.EstimatedCompletedDate;
            this.EstimatedDuration = data.EstimatedDuration;
            this.IsArchived = data.IsArchived;
            this.ProjectId = data.ProjectId;
            this.ProjectName = data.Project.Name;
            this.SprintId = data.SprintId;
            this.SprintName = data.Sprint.Name;
            this.StartDate = data.StartDate;
            this.StatusId = data.StatusId;
            this.StatusName = data.Status.Name;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
        }
    }
}
