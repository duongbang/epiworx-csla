using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class UserFormModel : ModelBase
    {
        public User User { get; set; }
        public IEnumerable<ProjectInfo> Projects { get; set; }
        public IEnumerable<StoryInfo> Stories { get; set; }
        public ProjectListModel ProjectListModel { get; set; }
        public HourSummaryByDateListModel CurrentWeekHourSummaryByDateListModel { get; set; }
        public HourSummaryByDateListModel TrailingWeeksHourSummaryByDateListModel { get; set; }
        public HourSummaryListModel HourSummaryListModel { get; set; }
        public TimelineListModel TimelineListModel { get; set; }

        public UserFormModel()
        {
            this.Title = "User";
        }
    }
}