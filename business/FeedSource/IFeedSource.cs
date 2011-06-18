using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IFeedSource
    {
        int FeedSourceMemberId { get; }
        int FeedId { get; }
        int SourceId { get; }
        string SourceName { get; }
        int SourceTypeId { get; }
        string SourceTypeName { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
