using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IStory
    {
        int StoryId { get; }
        int AssignedTo { get; }
        string AssignedToName { get; }
        DateTime AssignedDate { get; }
        int CategoryId { get; }
        string CategoryName { get; }
        DateTime CompletedDate { get; }
        string Description { get; }
        decimal Duration { get; }
        DateTime EstimatedCompletedDate { get; }
        decimal EstimatedDuration { get; }
        bool IsArchived { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        int SprintId { get; }
        string SprintName { get; }
        DateTime StartDate { get; }
        int StatusId { get; }
        string StatusName { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
    }
}
