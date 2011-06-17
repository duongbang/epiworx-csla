using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class HourInfo
    {
        private void Child_Fetch(HourData data)
        {
            this.HourId = data.HourId;
            this.Date = data.Date;
            this.Duration = data.Duration;
            this.IsArchived = data.IsArchived;
            this.Notes = data.Notes;
            this.StoryId = data.StoryId;
            this.UserId = data.UserId;
            this.UserName = data.User.Name;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }
    }
}
