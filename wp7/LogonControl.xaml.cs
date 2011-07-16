using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
    public partial class LogonControl : UserControl
    {
        public event EventHandler SignInCompleted;

        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }

        public string Title
        {
            get { return "logon"; }
        }

        public LogonControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.NameTextBox.Text = string.Empty;
            this.PasswordTextBox.Password = string.Empty;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameTextBox.Text)
                || string.IsNullOrEmpty(this.PasswordTextBox.Password))
            {
                return;
            }

            var proxy = new WebClient();

            var uri = string.Format(
                "http://localhost/EpiworxWcfRestService/Service/authorize/{0}/{1}",
                this.NameTextBox.Text,
                this.PasswordTextBox.Password);

            proxy.OpenReadCompleted += OnSignInCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnSignInCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            var result = new TokenData(xml);

            this.Token = result.Key;
            this.IsAuthenticated = true;

            IsolatedStorageSettings.ApplicationSettings["Name"] = this.NameTextBox.Text;
            IsolatedStorageSettings.ApplicationSettings["Password"] = this.PasswordTextBox.Password;

            if (this.SignInCompleted != null)
            {
                this.SignInCompleted(this, new RoutedEventArgs());
            }
        }
    }
}
