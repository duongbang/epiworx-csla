using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IFilter
    {
        int FilterId { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        string FilterQuery { get; }
        string Name { get; }
        int SourceTypeId { get; }
        string SourceTypeName { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
    }
}
