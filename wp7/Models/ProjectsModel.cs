using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Epiworx.Wp7.Helpers;

namespace Epiworx.Wp7.Models
{
    public class ProjectsModel : IModel
    {
        public event EventHandler<EventArgs> LoadCompleted;

        public string Token { get; set; }
        public IEnumerable<ProjectData> Projects { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsArchived { get; set; }

        public void Load()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                  "{0}/project?active={1}&archived={2}&token={3}",
                  ServiceHelper.ServiceUri,
                  DataHelper.ToString(this.IsActive),
                  DataHelper.ToString(this.IsArchived),
                  this.Token);

            proxy.OpenReadCompleted += OnLoadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnLoadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            this.Projects = xml.Elements()
                .Select(data => new ProjectData(data))
                .OrderBy(project => project.Name)
                .ToList();

            if (this.LoadCompleted != null)
            {
                this.LoadCompleted(sender, new EventArgs());
            }
        }

        public ProjectsModel()
        {
            this.IsActive = true;
            this.IsArchived = false;
        }
    }
}
