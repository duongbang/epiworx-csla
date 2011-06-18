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

        public ActionItem Add(string caption, string cssClass, string navigateUrl)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, cssClass, navigateUrl, string.Empty);
        }

        public ActionItem AddPrimary(string caption, string navigateUrl)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, "primary", navigateUrl, string.Empty);
        }

        public ActionItem AddPrimary(string caption, string navigateUrl, string imageUrl)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, "primary", navigateUrl, imageUrl);
        }

        public ActionItem AddSecondary(string caption, string navigateUrl)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, "secondary", navigateUrl, string.Empty);
        }

        public ActionItem AddSecondary(string caption, string navigateUrl, string imageUrl)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, "secondary", navigateUrl, imageUrl);
        }

        public ActionItem Add(string name, string caption, string cssClass, string navigateUrl, string imageUrl)
        {
            var item = new ActionItem();

            item.Name = name;
            item.Caption = caption;
            item.CssClass = cssClass;
            item.NavigateUrl = navigateUrl;
            item.ImageUrl = imageUrl;

            this.Add(item);

            return item;
        }
    }
}