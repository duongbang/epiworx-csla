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
            return this.Add(caption.Replace(" ", string.Empty), caption, navigateUrl, string.Empty, string.Empty);
        }

        public ActionItem Add(string caption, string navigateUrl, string cssClass)
        {
            return this.Add(caption.Replace(" ", string.Empty), caption, navigateUrl, string.Empty, cssClass);
        }

        public ActionItem Add(string name, string caption, string navigateUrl, string imageUrl, string cssClass)
        {
            var item = new ActionItem();

            item.Name = name;
            item.Caption = caption;
            item.CssClass = cssClass;
            item.NavigateUrl = navigateUrl;
            item.ImageUrl = imageUrl;

            if (name.ToLower().StartsWith("edit"))
            {
                item.CssClass += " edit";
            }
            else if (name.ToLower().StartsWith("add"))
            {
                item.CssClass += " add";
            }

            item.CssClass = item.CssClass.Trim();

            this.Add(item);

            return item;
        }
    }
}