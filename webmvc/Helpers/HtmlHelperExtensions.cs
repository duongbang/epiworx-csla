using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Epiworx.Business;
using Epiworx.Core;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Helpers
{
    using System.IO;

    public static class HtmlHelperExtensions
    {
        private const string GravatarUri = "http://www.gravatar.com/avatar/{0}?s={1}&d=identicon&r={2}";

        public static MvcHtmlString Gravatar(
            this HtmlHelper htmlHelper,
            string email,
            string title)
        {
            return htmlHelper.Gravatar(email, 60, "PG", title, title, string.Empty);
        }

        public static MvcHtmlString Gravatar(
            this HtmlHelper htmlHelper,
            string email,
            string title,
            string cssClass)
        {
            return htmlHelper.Gravatar(email, 60, "PG", title, title, cssClass);
        }

        public static MvcHtmlString Gravatar(
            this HtmlHelper htmlHelper,
            string email,
            int size,
            string rating,
            string alt,
            string title,
            string cssClass)
        {
            var img = new TagBuilder("img");

            img.Attributes.Add("src", string.Format(GravatarUri, MD5String(email), size, rating));

            if (!string.IsNullOrEmpty(alt))
            {
                img.Attributes.Add("alt", alt);
            }

            if (!string.IsNullOrEmpty(title))
            {
                img.Attributes.Add("title", title);
            }

            if (!string.IsNullOrEmpty(cssClass))
            {
                img.AddCssClass(cssClass);
            }

            return MvcHtmlString.Create(img.ToString());
        }

        private static string MD5String(string input)
        {
            var hash = new StringBuilder();
            var crypto = new MD5CryptoServiceProvider();
            var bytes = crypto.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (var i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }

        public static MvcHtmlString Clip(this HtmlHelper htmlHelper, string value, int maximumLength)
        {
            if (value.Length > maximumLength)
            {
                return new MvcHtmlString(value.Substring(0, maximumLength) + "...");
            }

            return new MvcHtmlString(value);
        }

        public static MvcHtmlString Clip(this HtmlHelper htmlHelper, string value, int maximumLength, string defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = defaultValue;
            }

            if (value.Length > maximumLength)
            {
                return new MvcHtmlString(value.Substring(0, maximumLength) + "...");
            }

            return new MvcHtmlString(value);
        }

        public static MvcHtmlString ToChanges(this HtmlHelper htmlHelper, string changes)
        {
            if (string.IsNullOrEmpty(changes))
            {
                return new MvcHtmlString(string.Empty);
            }

            var stringReader = new StringReader(changes);
            var xmlReader = new XmlTextReader(stringReader);

            var sb = new StringBuilder();

            sb.Append("<ul>");

            while (xmlReader.Read())
            {
                switch (xmlReader.Name)
                {
                    case "Name":
                        sb.Append("<li><span>");
                        sb.Append(xmlReader.ReadString());
                        sb.Append("</span>");
                        break;
                    case "NewValue":
                        sb.Append("&nbsp;&rarr;&nbsp;");
                        sb.Append(xmlReader.ReadString());
                        sb.Append("</li>");
                        break;
                }
            }

            sb.Append("</ul>");

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ToDefaultValue(this HtmlHelper htmlHelper, string value, string defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new MvcHtmlString(defaultValue);
            }

            return new MvcHtmlString(value);
        }

        public static MvcHtmlString Trim(this HtmlHelper htmlHelper, string value, int maximumLength)
        {
            if (value.Length > maximumLength)
            {
                return new MvcHtmlString(value.Substring(0, maximumLength) + "...");
            }

            return new MvcHtmlString(value);
        }

        public static MvcHtmlString ToChecked(this HtmlHelper htmlHelper, bool value)
        {
            if (value)
            {
                return new MvcHtmlString(" checked");
            }

            return new MvcHtmlString(string.Empty);
        }

        public static MvcHtmlString ToRelativeDate(this HtmlHelper htmlHelper, DateTime date)
        {
            return new MvcHtmlString(date.ToRelativeDate());
        }

        public static MvcHtmlString ToSelected(this HtmlHelper htmlHelper, object value, object checkValue)
        {
            if (value.ToString() == checkValue.ToString())
            {
                return new MvcHtmlString(" selected");
            }

            return new MvcHtmlString(string.Empty);
        }

        public static MvcHtmlString ToStringOfDates(this IEnumerable<HourSummaryByDate> values)
        {
            var sb = new StringBuilder();

            foreach (var value in values)
            {
                if (sb.Length != 0)
                {
                    sb.Append(",");
                }

                sb.Append(value.StartDate.ToString("MMM d"));
            }

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ToStringOfDurations(this IEnumerable<HourSummaryByDate> values)
        {
            var sb = new StringBuilder();

            foreach (var value in values)
            {
                if (sb.Length != 0)
                {
                    sb.Append(",");
                }

                sb.Append(value.Duration.ToString("F2"));
            }

            return new MvcHtmlString(sb.ToString());
        }
    }
}