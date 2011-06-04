using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class CategoryInfo
    {
        private void Child_Fetch(CategoryData data)
        {
		    this.CategoryId = data.CategoryId;
		    this.Description = data.Description;
		    this.IsActive = data.IsActive;
		    this.IsArchived = data.IsArchived;
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
