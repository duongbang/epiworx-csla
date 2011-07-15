using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IOrganization
    {
        int OrganizationId { get; }
        string Name { get; }
        string Description { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
    }
}
