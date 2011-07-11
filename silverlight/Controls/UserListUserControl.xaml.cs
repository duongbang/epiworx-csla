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
using Epiworx.Silverlight.Models;

namespace Epiworx.Silverlight
{
    public partial class UserListUserControl : UserControl
    {
        private UserListModel _model;
        public UserListModel Model
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
            this.Model.Updated += this.UpdatedCompleted;
        }

        private void UpdatedCompleted(object sender, RoutedEventArgs e)
        {
            this.UserListBox.ItemsSource = this.Model.Users;
        }

        public UserListUserControl()
        {
            InitializeComponent();
        }
    }
}
