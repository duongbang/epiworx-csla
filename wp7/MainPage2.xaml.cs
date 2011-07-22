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
using Microsoft.Phone.Controls;

namespace Epiworx.Wp7
{
    public partial class MainPage2 : PhoneApplicationPage
    {
        public MainPage2()
        {
            InitializeComponent();

            this.PageTitle.Text = this.LogonControl.Title;
            this.LogonControl.SignInCompleted += OnSignInCompleted;
            this.HomeControl.SelectedItemChanged += OnSelectedItemChanged;

            if (IsolatedStorageSettings.ApplicationSettings.Contains("Name")
                && IsolatedStorageSettings.ApplicationSettings.Contains("Password"))
            {
                this.Login();
            }
        }

        private void Login()
        {
            this.LogonControl.Visibility = Visibility.Collapsed;
            this.HomeControl.Visibility = Visibility.Visible;
            this.PageTitle.Text = this.HomeControl.Title;
        }

        private void Logout()
        {
            IsolatedStorageSettings.ApplicationSettings.Remove("Name");
            IsolatedStorageSettings.ApplicationSettings.Remove("Password");

            this.LogonControl.Clear();
            this.PageTitle.Text = this.LogonControl.Title;
            this.LogonControl.Visibility = Visibility.Visible;
            this.HomeControl.Visibility = Visibility.Collapsed;
            this.ProjectsControl.Visibility = Visibility.Collapsed;
            this.NewsFeedControl.Visibility = Visibility.Collapsed;
            this.UsersControl.Visibility = Visibility.Collapsed;
        }

        private void OnSignInCompleted(object sender, EventArgs e)
        {
            this.PageTitle.Text = this.HomeControl.Title;
            this.LogonControl.Visibility = Visibility.Collapsed;
            this.HomeControl.Visibility = Visibility.Visible;

            this.GetMe();
        }

        private void GetMe()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                "http://localhost/EpiworxWcfRestService/Service/user/?token={0}",
                this.LogonControl.Token);

            proxy.OpenReadCompleted += OnGetMeCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnGetMeCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            var result = new UserData(xml);

            this.HomeControl.User = result;
        }

        private void OnSelectedItemChanged(object sender, EventArgs e)
        {
            this.HomeControl.Visibility = Visibility.Collapsed;
            this.ProjectsControl.Visibility = Visibility.Collapsed;
            this.NewsFeedControl.Visibility = Visibility.Collapsed;
            this.UsersControl.Visibility = Visibility.Collapsed;

            switch (this.HomeControl.SelectedItem)
            {
                case "projects":
                    this.PageTitle.Text = this.ProjectsControl.Title;
                    this.ProjectsControl.Token = this.LogonControl.Token;
                    this.ProjectsControl.Load();
                    this.ProjectsControl.Visibility = Visibility.Visible;
                    break;
                case "news feed":
                    this.PageTitle.Text = this.NewsFeedControl.Title;
                    this.NewsFeedControl.Token = this.LogonControl.Token;
                    this.NewsFeedControl.Load();
                    this.NewsFeedControl.Visibility = Visibility.Visible;
                    break;
                case "users":
                    this.PageTitle.Text = this.UsersControl.Title;
                    this.UsersControl.Token = this.LogonControl.Token;
                    this.UsersControl.Load();
                    this.UsersControl.Visibility = Visibility.Visible;
                    break;
                case "log out":
                    this.Logout();
                    break;
                default:
                    break;
            }
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.HomeControl.Visibility != Visibility.Visible
                && this.LogonControl.Visibility != Visibility.Visible)
            {
                this.HomeControl.Clear();

                this.PageTitle.Text = this.HomeControl.Title;
                this.HomeControl.Visibility = Visibility.Visible;
                this.ProjectsControl.Visibility = Visibility.Collapsed;
                this.NewsFeedControl.Visibility = Visibility.Collapsed;
                this.UsersControl.Visibility = Visibility.Collapsed;

                e.Cancel = true;
            }
        }
    }
}