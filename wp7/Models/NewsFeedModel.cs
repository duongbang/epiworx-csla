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
    public class NewsFeedModel : IModel
    {
        public event EventHandler<EventArgs> LoadCompleted;

        public string Token { get; set; }
        public IEnumerable<FeedData> Feeds { get; set; }
        public string CreatedDate { get; set; }
        public int SkipRecords { get; set; }
        public int MaximumRecords { get; set; }

        public void Load()
        {
            var proxy = new WebClient();

            var uri = string.Format(
                  "{0}/feed?createdDate={1}&maximumRecords={2}&token={3}",
                  ServiceHelper.ServiceUri,
                  this.CreatedDate,
                  this.MaximumRecords,
                  this.Token);

            proxy.OpenReadCompleted += OnLoadCompleted;

            proxy.OpenReadAsync(new Uri(uri, UriKind.Absolute));
        }

        private void OnLoadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var xml = XElement.Load(e.Result);

            this.Feeds = xml.Elements()
                .Select(data => new FeedData(data))
                .OrderByDescending(feed => feed.CreatedDate)
                .ToList();

            if (this.LoadCompleted != null)
            {
                this.LoadCompleted(sender, new EventArgs());
            }
        }

        public NewsFeedModel()
        {
            this.MaximumRecords = 20;
        }
    }
}
