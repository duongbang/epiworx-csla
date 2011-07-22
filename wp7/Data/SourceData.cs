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
    public class SourceData
    {
        public int SourceId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public SourceData()
        {
        }

        public SourceData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.SourceId = int.Parse(data.Element(ns + "SourceId").Value);
            this.Type = data.Element(ns + "Type").Value;
            this.Name = data.Element(ns + "Name").Value;
        }
    }
}