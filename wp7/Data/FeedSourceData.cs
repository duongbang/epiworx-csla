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
    public class FeedSourceData
    {
        public int FeedSourceMemberId { get; set; }
        public int FeedId { get; set; }
        public SourceData Source { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public FeedSourceData()
        {
        }

        public FeedSourceData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.FeedSourceMemberId = int.Parse(data.Element(ns + "FeedSourceMemberId").Value);
            this.FeedId = int.Parse(data.Element(ns + "FeedId").Value);
            this.Source = new SourceData(data.Element(ns + "Source"));
            this.CreatedBy = new UserData(data.Element(ns + "CreatedBy"));
            this.CreatedDate = DateTime.Parse(data.Element(ns + "CreatedDate").Value);
        }
    }
}