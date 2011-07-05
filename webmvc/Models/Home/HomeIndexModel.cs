using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class HomeIndexModel : ModelBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public IEnumerable<HourInfo> Hours { get; set; }
        public HourSummaryByDateListModel CurrentWeekHourSummaryByDateListModel { get; set; }
        public HourSummaryByDateListModel TrailingWeeksHourSummaryByDateListModel { get; set; }
        public HourSummaryListModel HourSummaryListModel { get; set; }
        public ProjectListModel ProjectListModel { get; set; }
        public FeedListModel FeedListModel { get; set; }
        public TimelineListModel TimelineListModel { get; set; }

        public HomeIndexModel()
        {
            this.Title = "Dashboard";
            this.ProjectListModel = new ProjectListModel();
            this.FeedListModel = new FeedListModel();
            this.TimelineListModel = new TimelineListModel();
        }
    }
}