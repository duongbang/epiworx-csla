using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
{
    public class UserData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<TimelineData> Timelines { get; set; }

        public UserData()
        {
            this.Timelines = new List<TimelineData>();
        }

        public UserData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.UserId = int.Parse(data.Element(ns + "UserId").Value);
            this.Email = data.Element(ns + "Email").Value;
            this.Name = data.Element(ns + "Name").Value;
        }
    }
}
