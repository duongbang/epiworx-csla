using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Epiworx.WebMvc.Helpers
{
    public class CriteriaHelper
    {
        public static bool? ToBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            if (value == "false")
            {
                return false;
            }

            if (value == "true")
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