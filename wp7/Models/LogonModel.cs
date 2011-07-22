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
using Epiworx.Wp7.Helpers;

namespace Epiworx.Wp7.Models
{
    public class LogonModel : IModel
    {
        public event EventHandler<LogonEventArgs> LogonCompleted;

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; internal set; }
        public string Token { get; set; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(this.UserName))
                {
                    return false;
                }

                if (string.IsNullOrEmpty(this.Password))
                {
                    return false;
                }

                return true;
            }
        }

        public void Logon()
        {
            if (!this.IsValid)
            {
                this.IsAuthenticated = false;
                this.Token = string.Empty;
                return;
            }

            var proxy = new WebClient();

            var uri = string.Format(
                "{0}/authorize/{1}/{2}",
                ServiceHelper.ServiceUri,
                this.UserName,
                this.Password);

            proxy.OpenReadCompleted += OnLogonCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnLogonCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            var result = new TokenData(xml);

            this.Token = result.Key;
            this.IsAuthenticated = true;

            IsolatedStorageSettings.ApplicationSettings["UserName"] = this.UserName;
            IsolatedStorageSettings.ApplicationSettings["Password"] = this.Password;

            if (this.LogonCompleted != null)
            {
                this.LogonCompleted(
                    this,
                    new LogonEventArgs
                        {
                            IsAuthenticated = this.IsAuthenticated,
                            Token = this.Token
                        });
            }
        }

        public LogonModel()
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("UserName")
                || !IsolatedStorageSettings.ApplicationSettings.Contains("Password"))
            {
                return;
            }

            this.UserName = IsolatedStorageSettings.ApplicationSettings.Contains("UserName").ToString();
            this.Password = IsolatedStorageSettings.ApplicationSettings.Contains("Password").ToString();
        }
    }
}
