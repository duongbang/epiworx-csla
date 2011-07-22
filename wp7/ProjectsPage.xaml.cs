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
using Epiworx.Wp7.Controls;
using Epiworx.Wp7.Models;

namespace Epiworx.Wp7
{
    public partial class ProjectsPage : PhoneApplicationPage
    {
        private string Token { get; set; }
        private ProjectsModel Model { get; set; }

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

            var model = new ProjectsModel();

            model.Token = this.Token;
            model.IsActive = null;
            model.IsArchived = null;

            model.LoadCompleted += LoadCompleted;

            this.Model = model;

            model.Load();
        }

        private void LoadCompleted(object sender, EventArgs e)
        {
            this.LoadActiveProjects();
            this.LoadArchivedProjects();
            this.LoadInactiveProjects();

            this.BusyIndicator.Visibility = Visibility.Collapsed;
        }

        private void NavigateToLogonPage()
        {
            NavigationService.Navigate(new Uri("/LogonPage.xaml", UriKind.Relative));
        }

        private void LoadActiveProjects()
        {
            var model = new ProjectsModel();

            model.Projects = this.Model.Projects.Where(project => project.IsActive && !project.IsArchived);

            this.ActiveProjectsControl.DataContext = model;
        }

        private void LoadArchivedProjects()
        {
            var model = new ProjectsModel();

            model.Projects = this.Model.Projects.Where(project => project.IsArchived);

            this.ArchivedProjectsControl.DataContext = model;
        }

        private void LoadInactiveProjects()
        {
            var model = new ProjectsModel();

            model.Projects = this.Model.Projects.Where(project => !project.IsActive && !project.IsArchived);

            this.InactiveProjectsControl.DataContext = model;
        }

        public ProjectsPage()
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