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
using System.Xml;
using System.Xml.Linq;
using Epiworx.Silverlight.Data;

namespace Epiworx.Silverlight
{
    using Epiworx.Silverlight.Models;

    public partial class MainPage : UserControl
    {
        private MainModel _model;
        public MainModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                this.OnModelChanged();
            }
        }

        private void OnModelChanged()
        {
            this.SetPropertyStateBasedOnAuthentication();

            this.UpdateUserListControl();

            this.Model.SignInCompleted += this.SignInCompleted;
            this.Model.SignOutCompleted += this.SignOutCompleted;
        }

        private void SetPropertyStateBasedOnAuthentication()
        {
            if (this.Model.IsAuthenticated)
            {
                this.SignInStackPanel.Visibility = Visibility.Collapsed;
                this.WelcomeStackPanel.Visibility = Visibility.Visible;

                this.WelcomeTextBox.Text = string.Format("Welcome {0}!", this.Model.UserName);
            }
            else
            {
                this.SignInStackPanel.Visibility = Visibility.Visible;
                this.WelcomeStackPanel.Visibility = Visibility.Collapsed;
            }

            this.UserNameTextBox.Text = this.Model.UserName;
            this.PasswordTextBox.Password = this.Model.Password;
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void UpdateUserListControl()
        {
            if (this.Model.IsAuthenticated)
            {
                var model = new UserListModel();

                model.Token = this.Model.Token;
                model.ServiceUri = this.Model.ServiceUri;

                this.UserListUserControl.Model = model;

                model.Update();
            }
        }

        private void SignInCompleted(object sender, RoutedEventArgs e)
        {
            this.SetPropertyStateBasedOnAuthentication();

            this.UpdateUserListControl();
        }

        private void SignOutCompleted(object sender, RoutedEventArgs e)
        {
            this.SetPropertyStateBasedOnAuthentication();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            this.Model.UserName = this.UserNameTextBox.Text;
            this.Model.Password = this.PasswordTextBox.Password;

            this.Model.SignIn();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Model.SignOut();
        }
    }
}
