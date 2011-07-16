using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;

namespace Epiworx.Wp7.Helpers
{
    public class DataHelper
    {
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

    }
}
