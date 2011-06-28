using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IFeed
    {
        int FeedId { get; }
        string Action { get; }
        string Description { get; }
        int SourceId { get; }
        string SourceName { get; }
        int SourceTypeId { get; }
        string SourceTypeName { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
    }
}
