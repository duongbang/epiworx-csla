using System;
using System.Linq;
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
    public class ProjectData
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
        public string Name { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserData ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public TimelineData Status { get; set; }
        public Visibility StatusState
        {
            get
            {
                if (this.Status == null
                    || this.Status.CreatedBy == null
                    || string.IsNullOrEmpty(this.Status.CreatedBy.Name))
                {
                    return System.Windows.Visibility.Collapsed;
                }

                return System.Windows.Visibility.Visible;
            }
        }

        public ProjectData()
        {
        }

        public ProjectData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.ProjectId = int.Parse(data.Element(ns + "ProjectId").Value);
            this.Description = data.Element(ns + "Description").Value;
            this.IsActive = bool.Parse(data.Element(ns + "IsActive").Value);
            this.IsArchived = bool.Parse(data.Element(ns + "IsArchived").Value);
            this.Name = data.Element(ns + "Name").Value;
            this.Status = new TimelineData(data.Element(ns + "Timelines").Elements(ns + "TimelineData").FirstOrDefault());
        }
    }
}
