using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IStatus
    {
        int StatusId { get; }
        string Description { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        bool IsCompleted { get; }
        bool IsStarted { get; }
        string Name { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        int Ordinal { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
    }
}
