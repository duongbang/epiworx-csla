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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Epiworx.Wp7.Helpers;

namespace Epiworx.Wp7
{
    public partial class HomeControl : UserControl
    {
        public event EventHandler SelectedItemChanged;

        private UserData _user;
        public UserData User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                this.OnUserChanged();
            }
        }

        private void OnUserChanged()
        {
            this.NameTextBlock.Text = this.User.Name;
            string url = "http://www.gravatar.com/avatar/" + DataHelper.GetUrl(this.User.Email).ToLower() + ".jpg";
            this.PortraitImage.Source = new BitmapImage(
                    new Uri(url, UriKind.Absolute));
            this.StatusTextBlock.Text = this.User.Status.Body;
        }

        public string Title
        {
            get { return "home"; }
        }

        public string SelectedItem
        {
            get
            {
                if (this.NavigationListBox.SelectedItem == null)
                {
                    return string.Empty;
                }
                return ((ListBoxItem)this.NavigationListBox.SelectedItem).Content.ToString();
            }
        }

        public void Clear()
        {
            this.NavigationListBox.SelectedItem = null;
        }

        public HomeControl()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SelectedItemChanged != null)
            {
                this.SelectedItemChanged(sender, e);
            }
        }
    }
}
