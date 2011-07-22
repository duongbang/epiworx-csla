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

namespace Epiworx.Wp7.Models
{

    public class LogoutModel
    {
        public event EventHandler<EventArgs> LogoutCompleted;

        public string Token { get; set; }

        public void Logout()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("UserName"))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove("UserName");
            }

            if (IsolatedStorageSettings.ApplicationSettings.Contains("Password"))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove("Password");
            }

            this.OnLogoutCompleted(null, null);
        }

        private void OnLogoutCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (this.LogoutCompleted != null)
            {
                this.LogoutCompleted(sender, new EventArgs());
            }
        }
    }
}
