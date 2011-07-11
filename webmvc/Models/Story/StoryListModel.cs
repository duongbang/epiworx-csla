using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class StoryListModel : ModelBase
    {
        public IEnumerable<StoryInfo> Stories { get; set; }
        public IEnumerable<StatusInfo> Statuses { get; set; }
        public IEnumerable<UserInfo> Users { get; set; }

        public StoryListModel()
        {
            this.Title = "Stories";
        }
    }
}