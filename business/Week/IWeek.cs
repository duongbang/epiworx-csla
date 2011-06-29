using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IWeek
    {
		int WeekId { get; }
		DateTime EndDate { get; }
		int Period { get; }
		DateTime StartDate { get; }
		int Year { get; }
		int CreatedBy { get; }
		DateTime CreatedDate { get; }
		int ModifiedBy { get; }
		DateTime ModifiedDate { get; }
    }
}
