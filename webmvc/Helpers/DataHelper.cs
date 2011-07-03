using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Epiworx.Business;
using Epiworx.Data;

namespace Epiworx.WebMvc.Helpers
{
    public class CriteriaHelper
    {
        public static DateRangeCriteria ToDateRangeCriteria(DateTime startDate, DateTime endDate)
        {
            var result = new DateRangeCriteria(startDate, endDate);

            return result;
        }

        public static DateRangeCriteria ToDateRangeCriteria(string value)
        {
            var result = new DateRangeCriteria();

            if (!string.IsNullOrEmpty(value))
            {
                var dates = value.Split(',');

                if (dates.Count() == 1)
                {
                    result.DateFrom = DateTime.Parse(dates[0]);
                    result.DateTo = result.DateFrom;
                }
                else
                {
                    result.DateFrom = DateTime.Parse(dates[0]);
                    result.DateTo = DateTime.Parse(dates[1]);
                }
            }

            return result;
        }

        public static int[] ToArray(int? value)
        {
            if (value.HasValue)
            {
                return new[] { value.Value };
            }

            return null;
        }

        public static bool? ToBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            if (value.ToLower() == "false")
            {
                return false;
            }

            if (value.ToLower() == "true")
            {
                return true;
            }

            return null;
        }

        public static bool? ToBoolean(int? value, bool defaultValue)
        {
            if (!value.HasValue)
            {
                return defaultValue;
            }

            if (value.Value == 1)
            {
                return false;
            }

            if (value.Value == -1)
            {
                return true;
            }

            return null;
        }

        public static int ToInteger(int? value)
        {
            if (!value.HasValue)
            {
                return 0;
            }

            return value.Value;
        }
    }
}