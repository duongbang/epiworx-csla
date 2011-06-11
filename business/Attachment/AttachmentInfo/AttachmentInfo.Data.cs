using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class AttachmentInfo
    {
        private void Child_Fetch(AttachmentData data)
        {
            this.AttachmentId = data.AttachmentId;
            this.FileType = data.FileType;
            this.IsArchived = data.IsArchived;
            this.Name = data.Name;
            this.SourceId = data.SourceId;
            this.SourceName = data.Source.Name;
            this.SourceTypeId = data.SourceTypeId;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }
    }
}
