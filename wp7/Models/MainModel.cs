using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Wp7.Models
{
    public class MainModel : IModel
    {
        private const int MaximumSteps = 4;

        public event EventHandler<EventArgs> LoadCompleted;
        public event EventHandler<EventArgs> LoadNewsFeedCompleted;
        public event EventHandler<EventArgs> LoadProfileCompleted;
        public event EventHandler<EventArgs> LoadProjectsCompleted;
        public event EventHandler<EventArgs> LoadUsersCompleted;

        public ProfileModel ProfileModel { get; set; }
        public ProjectsModel ProjectsModel { get; set; }
        public UsersModel UsersModel { get; set; }
        public NewsFeedModel NewsFeedModel { get; set; }
        public string Token { get; set; }
        private int _currentStep = 0;
        private int CurrentStep
        {
            get
            {
                return _currentStep;
            }
            set
            {
                _currentStep = value;
                if (this.CurrentStep >= MaximumSteps)
                {
                    this.OnLoadCompleted(null, new EventArgs());
                }
            }
        }

        public bool IsLoaded
        {
            get { return this.CurrentStep == MaximumSteps; }
        }

        public void Load()
        {
            this.LoadNewsFeed();
            this.LoadProfile();
            this.LoadProjects();
            this.LoadUsers();
        }

        private void LoadProfile()
        {
            this.ProfileModel = new ProfileModel();

            this.ProfileModel.Token = this.Token;

            this.ProfileModel.LoadCompleted += OnLoadProfileCompleted;

            this.ProfileModel.Load();
        }

        private void OnLoadProfileCompleted(object sender, EventArgs e)
        {
            this.CurrentStep++;

            if (this.LoadProfileCompleted != null)
            {
                this.LoadProfileCompleted(sender, new EventArgs());
            }
        }

        private void LoadNewsFeed()
        {
            this.NewsFeedModel = new NewsFeedModel();

            this.NewsFeedModel.Token = this.Token;

            this.NewsFeedModel.LoadCompleted += OnLoadNewsFeedCompleted;

            this.NewsFeedModel.Load();
        }

        private void OnLoadNewsFeedCompleted(object sender, EventArgs e)
        {
            this.CurrentStep++;

            if (this.LoadNewsFeedCompleted != null)
            {
                this.LoadNewsFeedCompleted(sender, new EventArgs());
            }
        }

        private void LoadProjects()
        {
            this.ProjectsModel = new ProjectsModel();

            this.ProjectsModel.Token = this.Token;
            this.ProjectsModel.IsActive = true;
            this.ProjectsModel.IsArchived = false;

            this.ProjectsModel.LoadCompleted += OnLoadProjectsCompleted;

            this.ProjectsModel.Load();
        }

        private void OnLoadProjectsCompleted(object sender, EventArgs e)
        {
            this.CurrentStep++;

            if (this.LoadProjectsCompleted != null)
            {
                this.LoadProjectsCompleted(sender, new EventArgs());
            }
        }

        private void LoadUsers()
        {
            this.UsersModel = new UsersModel();

            this.UsersModel.Token = this.Token;

            this.UsersModel.LoadCompleted += OnLoadUsersCompleted;

            this.UsersModel.Load();
        }

        private void OnLoadUsersCompleted(object sender, EventArgs e)
        {
            this.CurrentStep++;

            if (this.LoadUsersCompleted != null)
            {
                this.LoadUsersCompleted(sender, new EventArgs());
            }
        }

        private void OnLoadCompleted(object sender, EventArgs e)
        {
            if (this.LoadCompleted != null)
            {
                this.LoadCompleted(sender, new EventArgs());
            }
        }
    }
}
