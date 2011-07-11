using System;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Silverlight.Helpers
{
    public class CookieHelper
    {
        public static bool Exists(string key, string value)
        {
            return HtmlPage.Document.Cookies.Contains(key + "=" + value);
        }

        public static string Read(string key)
        {
            var cookies = HtmlPage.Document.Cookies.Split(';');

            foreach (string cookie in cookies)
            {
                var keyValuePair = cookie.Split('=');
                if (keyValuePair.Length == 2 && key == keyValuePair[0].Trim())
                {
                    return keyValuePair[1].Trim();
                }
            }

            return null;
        }

        public static void Write(string key, string value, int expireDays)
        {
            // expireDays = 0, indicates a session cookie that will not be written to disk             
            // expireDays = -1, indicates that the cookie will not expire and will be permanent            
            // expireDays = n, indicates that the cookie will expire in “n” days            
            var expires = string.Empty;

            if (expireDays != 0)
            {
                var expireDate = (expireDays > 0 ? DateTime.Now + TimeSpan.FromDays(expireDays) : DateTime.MaxValue);
                expires = ";expires=" + expireDate.ToString("R");
            }

            var cookie = key + "=" + value + expires;

            HtmlPage.Document.SetProperty("cookie", cookie);
        }

        public static void Delete(string key)
        {
            var expireDate = DateTime.Now - TimeSpan.FromDays(1); // yesterday            
            var expires = ";expires=" + expireDate.ToString("R");
            var cookie = key + "=" + expires;

            HtmlPage.Document.SetProperty("cookie", cookie);
        }
    }
}
