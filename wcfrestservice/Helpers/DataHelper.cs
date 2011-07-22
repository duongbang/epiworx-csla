using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Data;

namespace Epiworx.WcfRestService.Helpers
{
    public class DataHelper
    {
        public static bool? ToBoolean(string value)
        {
            if (value == "true")
            {
                return true;
            }

            if (value == "false")
            {
                return false;
            }

            return null;
        }

        public static int? ToInteger(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return null;
            }
        }

        public static DateRangeCriteria ToDateRange(string value)
        {
            var result = new DateRangeCriteria(value);

            if (result.DateFrom == DateTime.MinValue
                && result.DateTo == DateTime.MaxValue)
            {
                result = null;
            }

            return result;
        }
    }
}