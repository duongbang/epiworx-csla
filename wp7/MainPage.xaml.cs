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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Epiworx.Wp7.Models;

namespace Epiworx.Wp7
{
    public partial class MainPage : PhoneApplicationPage
    {
        private enum NavigationLocation
        {
            NewsFeed = 0,
            Projects = 1,
            Users = 2,
            Logout = 3
        }

        public MainModel Model { get; set; }
        private string Token { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Load()
        {
            this.BusyIndicator.Visibility = Visibility.Visible;

            this.Model = new MainModel();

            this.Model.Token = this.Token;

            this.Model.LoadProfileCompleted += LoadProfileCompleted;
            this.Model.LoadCompleted += LoadCompleted;

            this.Model.Load();
        }

        private void LoadCompleted(object sender, EventArgs e)
        {
            this.ProjectsControl.Model = this.Model.ProjectsModel;
            this.UsersControl.Model = this.Model.UsersModel;
            this.NewsFeedControl.Model = this.Model.NewsFeedModel;

            this.BusyIndicator.Visibility = Visibility.Collapsed;
        }

        private void LoadProfileCompleted(object sender, EventArgs e)
        {
            this.ProfileControl.Model = this.Model.ProfileModel;
        }

        private void NavigateToLogonPage()
        {
            NavigationService.Navigate(new Uri("/LogonPage.xaml", UriKind.Relative));
        }

        private void NavigateToNewsFeedPage()
        {
            NavigationService.Navigate(new Uri(string.Format("/NewsFeedPage.xaml?token={0}", this.Token), UriKind.Relative));
        }

        private void NavigateToProjectsPage()
        {
            NavigationService.Navigate(new Uri(string.Format("/ProjectsPage.xaml?token={0}", this.Token), UriKind.Relative));
        }

        private void NavigateToUsersPage()
        {
            NavigationService.Navigate(new Uri(string.Format("/UsersPage.xaml?token={0}", this.Token), UriKind.Relative));
        }

        private void ClearNavigation()
        {
            this.NavigationListBox.SelectedItem = null;
        }

        private void HandleNavigationRequest(NavigationLocation request)
        {
            switch (request)
            {
                case NavigationLocation.NewsFeed:
                    this.NavigateToNewsFeedPage();
                    break;
                case NavigationLocation.Projects:
                    this.NavigateToProjectsPage();
                    break;
                case NavigationLocation.Users:
                    this.NavigateToUsersPage();
                    break;
                case NavigationLocation.Logout:
                    this.Logout();
                    break;
            }
        }

        private void Logout()
        {
            var model = new LogoutModel();

            model.LogoutCompleted += LogoutCompleted;

            model.Logout();
        }

        private void LogoutCompleted(object sender, EventArgs e)
        {
            this.Token = string.Empty;

            NavigationService.Navigate(new Uri("/LogonPage.xaml", UriKind.Relative));
        }

        private bool HasAuthenticationToken()
        {
            if (this.NavigationContext.QueryString.ContainsKey("token"))
            {
                this.Token = this.NavigationContext.QueryString["token"];

                return true;
            }

            return false;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.HasAuthenticationToken())
            {
                this.ClearNavigation();

                this.Load();
            }
            else
            {
                this.NavigateToLogonPage();
            }
        }

        private void NavigationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.HandleNavigationRequest((NavigationLocation)this.NavigationListBox.SelectedIndex);
        }
    }
}