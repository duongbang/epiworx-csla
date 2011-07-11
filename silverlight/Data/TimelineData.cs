using System;
using System.Net;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    using System.Linq;

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

        public TimelineData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.TimelineId = int.Parse(data.Element(ns + "TimelineId").Value);
            this.Body = data.Element(ns + "Body").Value;
            this.IsArchived = bool.Parse(data.Element(ns + "IsArchived").Value);
            this.CreatedBy = new UserData(data.Element(ns + "CreatedBy"));
            this.CreatedDate = DateTime.Parse(data.Element(ns + "CreatedDate").Value);
            this.ModifiedDate = DateTime.Parse(data.Element(ns + "ModifiedDate").Value);
        }
    }
}
