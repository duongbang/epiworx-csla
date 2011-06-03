using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ISprint
    {
        int SprintId { get; }
        DateTime CompletedDate { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        bool IsCompleted { get; }
        decimal Duration { get; }
        DateTime EstimatedCompletedDate { get; }
        decimal EstimatedDuration { get; }
        string Name { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
    }
}
