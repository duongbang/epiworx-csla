using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class SprintInfo
    {
        private void Child_Fetch(SprintData data)
        {
            this.SprintId = data.SprintId;
            this.CompletedDate = data.CompletedDate;
            this.IsActive = data.IsActive;
            this.IsArchived = data.IsArchived;
            this.IsCompleted = data.IsCompleted;
            this.Duration = data.Duration;
            this.EstimatedCompletedDate = data.EstimatedCompletedDate;
            this.EstimatedDuration = data.EstimatedDuration;
            this.Name = data.Name;
            this.ProjectId = data.ProjectId;
            this.ProjectName = data.Project.Name;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }
    }
}
