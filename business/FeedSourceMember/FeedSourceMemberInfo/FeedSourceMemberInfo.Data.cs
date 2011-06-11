using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSourceMemberInfo
    {
        private void Child_Fetch(FeedSourceMemberData data)
        {
            this.FeedSourceMemberId = data.FeedSourceMemberId;
            this.FeedId = data.FeedId;
            this.SourceId = data.SourceId;
            this.SourceName = data.Source.Name;
            this.SourceTypeId = data.SourceTypeId;
            this.CreatedBy = data.CreatedBy;
            // this.CreatedByName = data.CreatedByUser.Name; // Don't need to display, will remove later
            this.CreatedDate = data.CreatedDate;
        }
    }
}
