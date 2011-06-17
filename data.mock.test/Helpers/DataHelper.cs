using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Test.Helpers
{
    public class DataHelper
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        public static DateTime RandomDateTime()
        {
            var start = new DateTime(2010, 1, 1);
            var gen = new Random();
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public static int RandomInteger(int length)
        {
            return new System.Random().Next(100000);
        }

        public static decimal RandomDecimal(int length, int precision)
        {
            return new System.Random().Next(100000);
        }

        public static string RandomEmail()
        {
            var sb = new StringBuilder();

            sb.Append(DataHelper.RandomString(10));
            sb.Append("@");
            sb.Append(DataHelper.RandomString(20));
            sb.Append(".com");

            return sb.ToString();
        }

        public static string RandomPhoneNumber()
        {
            var sb = new StringBuilder();

            sb.Append("(");
            sb.Append(DataHelper.RandomNumber(3));
            sb.Append(") ");
            sb.Append(DataHelper.RandomNumber(3));
            sb.Append("-");
            sb.Append(DataHelper.RandomNumber(4));

            return sb.ToString();
        }

        public static int RandomNumber(int maxValue)
        {
            return DataHelper.RandomNumber(0, maxValue);
        }

        public static int RandomNumber(int minValue, int maxValue)
        {
            var random = new Random();

            return random.Next(minValue, maxValue);
        }

        public static string RandomPassword(int length)
        {
            var sb = new StringBuilder();

            sb.Append("1");
            sb.Append("A");
            sb.Append("a");
            sb.Append("!");

            for (var i = 0; i < length; i++)
            {
                sb.Append(
                    Convert.ToChar(Convert.ToInt32(Math.Floor((26 * DataHelper.Random.NextDouble()) + 65))));
            }

            if (sb.Length > 10)
            {
                sb.Append(DateTime.Now.ToString("hhMMssffff"));
                sb.Remove(0, 10);
            }
            else if (sb.Length > 6)
            {
                sb.Append(DateTime.Now.ToString("hhMMss"));
                sb.Remove(0, 6);
            }

            return sb.ToString();
        }

        public static string RandomString(int length)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                sb.Append(
                    Convert.ToChar(Convert.ToInt32(Math.Floor((26 * DataHelper.Random.NextDouble()) + 65))));
            }

            if (sb.Length > 10)
            {
                sb.Append(DateTime.Now.ToString("hhMMssffff"));
                sb.Remove(0, 10);
            }
            else if (sb.Length > 6)
            {
                sb.Append(DateTime.Now.ToString("hhMMss"));
                sb.Remove(0, 6);
            }

            return sb.ToString();
        }
    }
}
