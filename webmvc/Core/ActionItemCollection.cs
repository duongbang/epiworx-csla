using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Epiworx.WebMvc
{
    [Serializable]
    public class ActionItemCollection : List<ActionItem>
    {
        public ActionItem this[string name]
        {
            get { return this.Where(row => row.Name == name).Single(); }
        }

        public ActionItem Add(string caption, string navigateUrl)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, navigateUrl, string.Empty);
        }

        public ActionItem Add(string name, string caption, string navigateUrl, string imageUrl)
        {
            var item = new ActionItem();

            item.Name = name;
            item.Caption = caption;
            item.NavigateUrl = navigateUrl;
            item.ImageUrl = imageUrl;

            this.Add(item);

            return item;
        }
    }
}