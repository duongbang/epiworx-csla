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

namespace Epiworx.Wp7
{
    using System.Xml.Linq;

    public partial class ProjectsControl : UserControl
    {
        public string Token { get; set; }

        public string Title
        {
            get { return "projects"; }
        }

        public void Load()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                "http://localhost/EpiworxWcfRestService/Service/project?token={0}",
                this.Token);

            proxy.OpenReadCompleted += OnOpenReadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);
            var projects = new List<ProjectData>();

            foreach (var data in xml.Elements())
            {
                projects.Add(new ProjectData(data));

            }

            this.ProjectsListBox.ItemsSource = projects
                .Where(row => row.IsActive && !row.IsArchived)
                .AsEnumerable();
        }

        public ProjectsControl()
        {
            InitializeComponent();
        }
    }
}
