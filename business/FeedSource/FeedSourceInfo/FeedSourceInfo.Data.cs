using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSourceInfo
    {
        private void Child_Fetch(FeedSourceMemberData data)
        {
            this.FeedSourceMemberId = data.FeedSourceMemberId;
            this.FeedId = data.FeedId;
            this.SourceId = data.SourceId;
            this.SourceName = data.Source.Name;
            this.SourceTypeId = data.SourceTypeId;
            this.CreatedBy = data.CreatedBy;
            this.CreatedDate = data.CreatedDate;
        }
    }
}
