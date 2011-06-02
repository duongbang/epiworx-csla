using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IProject
    {
		int ProjectId { get; }
		string Description { get; }
		bool IsActive { get; }
		bool IsArchived { get; }
		string Name { get; }
		int CreatedBy { get; }
		DateTime CreatedDate { get; }
		int ModifiedBy { get; }
		DateTime ModifiedDate { get; }
    }
}
