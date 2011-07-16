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
    public class TokenData
    {
        public string Key { get; set; }

        public TokenData()
        {
        }

        public TokenData(XElement data)
            : this()
        {
            var ns = data.GetDefaultNamespace();

            this.Key = data.Element(ns + "Key").Value;
        }
    }
}
