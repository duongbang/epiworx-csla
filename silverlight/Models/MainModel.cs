using System;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Epiworx.Silverlight.Data;

namespace Epiworx.Silverlight.Models
{
    public class MainModel
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string ServiceUri { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public event RoutedEventHandler SignInCompleted;
        public event RoutedEventHandler SignOutCompleted;

        public void SignIn()
        {
            if (string.IsNullOrEmpty(this.UserName)
                || string.IsNullOrEmpty(this.Password))
            {
                return;
            }

            var proxy = new WebClient();

            var uri = string.Format(
                "{0}/authorize/{1}/{2}",
                this.ServiceUri,
                this.UserName,
                this.Password);

            proxy.OpenReadCompleted += OnSignInCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnSignInCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            var result = new TokenData(xml);

            this.Token = result.Key;
            this.IsAuthenticated = true;

            IsolatedStorageSettings.ApplicationSettings["UserName"] = this.UserName;
            IsolatedStorageSettings.ApplicationSettings["Password"] = this.Password;

            if (this.SignInCompleted != null)
            {
                this.SignInCompleted(this, new RoutedEventArgs());
            }
        }

        public void SignOut()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Token = string.Empty;
            this.IsAuthenticated = false;

            IsolatedStorageSettings.ApplicationSettings["UserName"] = string.Empty;
            IsolatedStorageSettings.ApplicationSettings["Password"] = string.Empty;

            if (this.SignOutCompleted != null)
            {
                this.SignOutCompleted(this, new RoutedEventArgs());
            }
        }
    }
}
