using System;
using System.Net;
using System.Xml.Linq;

namespace Epiworx.Silverlight.Data
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
