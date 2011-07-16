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
using System.Xml.Linq;

namespace Epiworx.Wp7
{
    public partial class NewsFeedControl : UserControl
    {
        public string Token { get; set; }

        public string Title
        {
            get { return "news feed"; }
        }

        public void Load()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                "http://localhost/EpiworxWcfRestService/Service/feed?maximumRecords=20&token={0}",
                this.Token);

            proxy.OpenReadCompleted += OnOpenReadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);
            var feeds = new List<FeedData>();

            foreach (var data in xml.Elements())
            {
                feeds.Add(new FeedData(data));

            }

            this.FeedsListBox.ItemsSource = feeds
                .OrderByDescending(feed => feed.CreatedDate)
                .AsEnumerable();
        }


        public NewsFeedControl()
        {
            InitializeComponent();
        }
    }
}
