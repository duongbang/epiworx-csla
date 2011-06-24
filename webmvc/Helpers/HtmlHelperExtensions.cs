using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.Core;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Helpers
{
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