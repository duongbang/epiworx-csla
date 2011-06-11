using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class NoteInfo
    {
        private void Child_Fetch(NoteData data)
        {
            this.NoteId = data.NoteId;
            this.Body = data.Body;
            this.IsArchived = data.IsArchived;
            this.SourceId = data.SourceId;
            this.SourceName = data.Source.Name;
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
