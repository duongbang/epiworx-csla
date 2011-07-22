using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Epiworx.Wp7.Helpers;

namespace Epiworx.Wp7.Models
{
    public class ProfileModel : IModel
    {
        public event EventHandler<EventArgs> LoadCompleted;

        public UserData User { get; set; }
        public string Token { get; set; }

        public void Load()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                "{0}/user/?token={1}",
                ServiceHelper.ServiceUri,
                this.Token);

            proxy.OpenReadCompleted += OnLoadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnLoadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            this.User = new UserData(xml);

            if (this.LoadCompleted != null)
            {
                this.LoadCompleted(sender, new EventArgs());
            }
        }
    }
}
