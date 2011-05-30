using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Core
{
    public static class StringExtensions
    {
        public static string Left(this string text, int length)
        {
            if (text.Length <= length)
            {
                return text;
            }

            return text.Substring(0, length);
        }

        public static string Right(this string text, int length)
        {
            if (text.Length <= length)
            {
                return text;
            }

            return text.Substring(text.Length - length, length);
        }
    }
}
