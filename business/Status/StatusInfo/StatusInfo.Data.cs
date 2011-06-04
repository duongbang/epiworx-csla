using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class StatusInfo
    {
        private void Child_Fetch(StatusData data)
        {
		    this.StatusId = data.StatusId;
		    this.Description = data.Description;
		    this.IsActive = data.IsActive;
		    this.IsArchived = data.IsArchived;
		    this.IsCompleted = data.IsCompleted;
		    this.IsStarted = data.IsStarted;
		    this.Name = data.Name;
		    this.Ordinal = data.Ordinal;
		    this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
		    this.CreatedDate = data.CreatedDate;
		    this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
		    this.ModifiedDate = data.ModifiedDate;
        }
    }
}
