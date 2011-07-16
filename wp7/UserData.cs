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

    public class UserData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public TimelineData Status { get; set; }

        public UserData()
        {
        }

        public UserData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.UserId = int.Parse(data.Element(ns + "UserId").Value);
            this.Email = data.Element(ns + "Email").Value;
            this.Name = data.Element(ns + "Name").Value;
            this.Status = new TimelineData(data.Element(ns + "Timelines").Elements(ns + "TimelineData").FirstOrDefault());
        }
    }
}
