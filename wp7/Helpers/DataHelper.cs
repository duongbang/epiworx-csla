using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text;

namespace Epiworx.Wp7.Helpers
{
    public class DataHelper
    {
        public static string ToString(bool? value)
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            if (value.Value)
            {
                return "true";
            }

            return "false";
        }

        public static string GetUrl(string email)
        {
            var sb = new StringBuilder();
            var text = Encoding.UTF8.GetBytes(email.ToLower().Trim());
            var md5hash = CryptoHelper.GetHash(text);

            foreach (byte b in md5hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        public static BitmapImage GetGravatar(string email)
        {
            var url = string.Format("http://www.gravatar.com/avatar/{0}.jpg",
                DataHelper.GetUrl(email).ToLower());

            return new BitmapImage(new Uri(url, UriKind.Absolute));
        }

        public static string GetGravatarUrl(string email)
        {
            var sb = new StringBuilder();
            var text = Encoding.UTF8.GetBytes(email.ToLower().Trim());
            var md5hash = CryptoHelper.GetHash(text);

            foreach (byte b in md5hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
