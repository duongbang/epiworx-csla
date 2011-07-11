using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserListModel
    {
        public string Token { get; set; }
        public string ServiceUri { get; set; }
        public IEnumerable<UserData> Users { get; set; }

        public event RoutedEventHandler Updated;

        public void Update()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                "{0}/user?token={1}",
                this.ServiceUri,
                this.Token);

            proxy.OpenReadCompleted += OnUpdateCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnUpdateCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);
            var ns = xml.GetDefaultNamespace();

            this.Users = xml.Elements(ns + "UserData")
                .Select(row => new UserData(row))
                .ToList();

            if (this.Updated != null)
            {
                this.Updated(this, new RoutedEventArgs());
            }
        }
    }
}
