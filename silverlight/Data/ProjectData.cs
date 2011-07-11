using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
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
        public List<TimelineData> Timelines { get; set; }

        public ProjectData()
        {
            this.CreatedBy = new UserData();
            this.ModifiedBy = new UserData();
            this.Timelines = new List<TimelineData>();
        }

        public ProjectData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.ProjectId = int.Parse(data.Element(ns + "ProjectId").Value);
            this.Name = data.Element(ns + "Name").Value;
            this.Description = data.Element(ns + "Description").Value;
            this.IsActive = bool.Parse(data.Element(ns + "IsActive").Value);
            this.IsArchived = bool.Parse(data.Element(ns + "IsArchived").Value);
            this.CreatedBy = new UserData(data.Element(ns + "CreatedBy"));
            this.CreatedDate = DateTime.Parse(data.Element(ns + "CreatedDate").Value);
            this.ModifiedDate = DateTime.Parse(data.Element(ns + "ModifiedDate").Value);
        }
    }
}
