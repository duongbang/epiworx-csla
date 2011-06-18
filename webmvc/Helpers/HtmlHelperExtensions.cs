using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Helpers
{
    using Epiworx.Business;
    using Epiworx.Core;

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ToChecked(this HtmlHelper html, bool value)
        {
            if (value)
            {
                return new MvcHtmlString(" checked");
            }

            return new MvcHtmlString(string.Empty);
        }

        public static MvcHtmlString ToRelativeDate(this HtmlHelper html, DateTime date)
        {
            return new MvcHtmlString(date.ToRelativeDate());
        }

        public static MvcHtmlString ToSelected(this HtmlHelper html, object value, object checkValue)
        {
            if (value.ToString() == checkValue.ToString())
            {
                return new MvcHtmlString(" selected");
            }

            return new MvcHtmlString(string.Empty);
        }
    }
}