using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class HourIndexModel : ModelBase
    {
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public IEnumerable<HourInfo> Hours { get; set; }
        public IEnumerable<Week> Weeks { get; set; }
        public IEnumerable<UserInfo> Users { get; set; }
        public IEnumerable<int> Years { get; set; }

        public HourIndexModel()
        {
            this.Title = "Hours";
        }
    }
}