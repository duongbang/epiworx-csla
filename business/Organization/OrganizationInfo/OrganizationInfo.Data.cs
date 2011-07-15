using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class OrganizationInfo
    {
        private void Child_Fetch(OrganizationData data)
        {
            this.OrganizationId = data.OrganizationId;
            this.Name = data.Name;
            this.Description = data.Description;
            this.IsActive = data.IsActive;
            this.IsArchived = data.IsArchived;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
        }
    }
}
