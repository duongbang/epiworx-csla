using System;
using System.Collections.Generic;
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
    public class FeedData
    {
        public int FeedId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public SourceData Source { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text
        {
            get { return string.Format("{0} {1} {2} {3}", this.CreatedBy.Name, this.Action, this.Source.Type, this.Source.Name); }
        }
        public string RelativeCreatedDate
        {
            get { return this.CreatedDate.ToRelativeDate(); }
        }
        public List<FeedSourceData> Sources { get; set; }

        public FeedData()
        {
            this.Sources = new List<FeedSourceData>();
        }

        public FeedData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.FeedId = int.Parse(data.Element(ns + "FeedId").Value);
            this.Action = data.Element(ns + "Action").Value;
            this.Description = data.Element(ns + "Description").Value;
            this.Source = new SourceData(data.Element(ns + "Source"));
            this.CreatedBy = new UserData(data.Element(ns + "CreatedBy"));
            this.CreatedDate = DateTime.Parse(data.Element(ns + "CreatedDate").Value);

            foreach (var childData in data.Element(ns + "Sources").Elements(ns + "FeedSourceData"))
            {
                this.Sources.Add(new FeedSourceData(childData));
            }
        }
    }
}