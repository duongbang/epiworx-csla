using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class WeekInfo
    {
        private void Child_Fetch(WeekData data)
        {
		    this.WeekId = data.WeekId;
		    this.EndDate = data.EndDate;
		    this.Period = data.Period;
		    this.StartDate = data.StartDate;
		    this.Year = data.Year;
		    this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
		    this.CreatedDate = data.CreatedDate;
		    this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
		    this.ModifiedDate = data.ModifiedDate;
        }
    }
}
