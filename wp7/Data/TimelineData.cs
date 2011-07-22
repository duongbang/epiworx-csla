using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Epiworx.Wp7
{
    public class TimelineData
    {
        public int TimelineId { get; set; }
        public string Body { get; set; }
        public bool IsArchived { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RelativeCreatedDate
        {
            get { return this.CreatedDate.ToRelativeDate(); }
        }
        public UserData ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public TimelineData()
        {
        }

        public TimelineData(XElement data)
            : this()
        {
            if (data == null)
            {
                this.Body = "Move along, nothing to report here";
                return;
            }

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
