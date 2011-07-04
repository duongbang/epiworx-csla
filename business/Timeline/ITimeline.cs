using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ITimeline
    {
        int TimelineId { get; }
        string Body { get; }
        bool IsArchived { get; }
        int SourceId { get; }
        string SourceName { get; }
        int SourceTypeId { get; }
        string SourceTypeName { get; }
        int CreatedBy { get; }
        string CreatedByEmail { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        string ModifiedByEmail { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
    }
}
