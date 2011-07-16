using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Epiworx.Wp7
{
    public partial class UsersControl : UserControl
    {
        public string Token { get; set; }

        public string Title
        {
            get { return "users"; }
        }

        public void Load()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                "http://localhost/EpiworxWcfRestService/Service/user?token={0}",
                this.Token);

            proxy.OpenReadCompleted += OnOpenReadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);
            var users = new List<UserData>();

            foreach (var data in xml.Elements())
            {
                users.Add(new UserData(data));

            }

            this.UsersListBox.ItemsSource = users
                .AsEnumerable();
        }

        public UsersControl()
        {
            InitializeComponent();
        }
    }
}
