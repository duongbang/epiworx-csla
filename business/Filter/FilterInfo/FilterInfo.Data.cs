using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FilterInfo
    {
        private void Child_Fetch(FilterData data)
        {
            this.FilterId = data.FilterId;
            this.IsActive = data.IsActive;
            this.IsArchived = data.IsArchived;
            this.FilterQuery = data.FilterQuery;
            this.Name = data.Name;
            this.SourceTypeId = data.SourceTypeId;
            this.SourceTypeName = data.SourceType.Name;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }
    }
}
