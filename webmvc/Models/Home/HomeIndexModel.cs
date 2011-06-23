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
        public IEnumerable<ProjectInfo> Projects { get; set; }
        public IEnumerable<HourInfo> Hours { get; set; }

        public HomeIndexModel()
        {
            this.Title = "Dashboard";
        }
    }
}