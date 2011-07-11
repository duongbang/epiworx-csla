using System;
using System.Collections.Generic;
using Epiworx.Business;

namespace Epiworx.WcfRestService
{
    public class TimelineData
    {
        public int TimelineId { get; set; }
        public string Body { get; set; }
        public bool IsArchived { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserData ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public TimelineData()
        {
        }

        public TimelineData(TimelineInfo timeline)
            : this()
        {
            this.TimelineId = timeline.TimelineId;
            this.Body = timeline.Body;
            this.IsArchived = timeline.IsArchived;
            this.CreatedBy = new UserData(timeline.CreatedBy, timeline.CreatedByName, timeline.CreatedByEmail);
            this.CreatedDate = timeline.CreatedDate;
            this.ModifiedBy = new UserData(timeline.ModifiedBy, string.Empty, string.Empty);
            this.ModifiedDate = timeline.ModifiedDate;
        }
    }
}
