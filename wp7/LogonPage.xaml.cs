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
using Epiworx.Wp7.Models;

namespace Epiworx.Wp7
{
    public partial class LogonPage : PhoneApplicationPage
    {
        private string Token { get; set; }
        private bool IsAuthenticated { get; set; }

        public LogonPage()
        {
            InitializeComponent();
        }

        private void Logon()
        {
            this.BusyIndicator.Visibility = Visibility.Visible;

            var model = new LogonModel();

            model.UserName = this.NameTextBox.Text;
            model.Password = this.PasswordTextBox.Password;

            model.LogonCompleted += LogonCompleted;

            model.Logon();
        }

        private void LogonCompleted(object sender, LogonEventArgs e)
        {
            this.IsAuthenticated = e.IsAuthenticated;
            this.Token = e.Token;

            this.BusyIndicator.Visibility = Visibility.Collapsed;

            if (this.IsAuthenticated)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml?token=" + this.Token, UriKind.Relative));
            }
        }

        private void LogonButton_Click(object sender, RoutedEventArgs e)
        {
            this.Logon();
        }
    }
}