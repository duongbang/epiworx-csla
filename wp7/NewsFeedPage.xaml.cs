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
using Microsoft.Phone.Controls;
using Epiworx.Wp7.Helpers;
using Epiworx.Wp7.Models;

namespace Epiworx.Wp7
{
    public partial class NewsFeedPage : PhoneApplicationPage
    {
        private string Token { get; set; }
        private NewsFeedModel Model { get; set; }

        private bool HasAuthenticationToken()
        {
            if (this.NavigationContext.QueryString.ContainsKey("token"))
            {
                this.Token = this.NavigationContext.QueryString["token"];

                return true;
            }

            return false;
        }

        private void Load()
        {
            this.BusyIndicator.Visibility = Visibility.Visible;

            var model = new NewsFeedModel();

            model.Token = this.Token;
            model.CreatedDate = "thismonth";

            model.LoadCompleted += LoadCompleted;

            this.Model = model;

            model.Load();
        }

        private void LoadCompleted(object sender, EventArgs e)
        {
            this.LoadTodayNewsFeeds();
            this.LoadYesterdayNewsFeeds();
            this.LoadThisWeekNewsFeeds();
            this.LoadThisMonthNewsFeeds();

            this.BusyIndicator.Visibility = Visibility.Collapsed;
        }

        private void NavigateToLogonPage()
        {
            NavigationService.Navigate(new Uri("/LogonPage.xaml", UriKind.Relative));
        }

        private void LoadTodayNewsFeeds()
        {
            var model = new NewsFeedModel();
            var createdDate = new DateRangeCriteria("today");

            model.Feeds = this.Model.Feeds.Where(feed =>
                feed.CreatedDate.Date >= createdDate.DateFrom && feed.CreatedDate.Date <= createdDate.DateTo);

            this.TodayNewsFeedControl.DataContext = model;
        }

        private void LoadYesterdayNewsFeeds()
        {
            var model = new NewsFeedModel();
            var createdDate = new DateRangeCriteria("yesterday");

            model.Feeds = this.Model.Feeds.Where(feed =>
                feed.CreatedDate.Date >= createdDate.DateFrom && feed.CreatedDate.Date <= createdDate.DateTo);

            this.YesterdayNewsFeedControl.DataContext = model;
        }

        private void LoadThisWeekNewsFeeds()
        {
            var model = new NewsFeedModel();
            var createdDate = new DateRangeCriteria("thisweek");

            model.Feeds = this.Model.Feeds.Where(feed =>
                feed.CreatedDate.Date >= createdDate.DateFrom && feed.CreatedDate.Date <= createdDate.DateTo);

            this.ThisWeekNewsFeedControl.DataContext = model;
        }

        private void LoadThisMonthNewsFeeds()
        {
            var model = new NewsFeedModel();

            model.Feeds = this.Model.Feeds;

            this.ThisMonthNewsFeedControl.DataContext = model;
        }

        public NewsFeedPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.HasAuthenticationToken())
            {
                this.Load();
            }
            else
            {
                this.NavigateToLogonPage();
            }
        }
    }
}