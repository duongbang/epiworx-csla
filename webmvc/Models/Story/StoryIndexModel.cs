using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class StoryIndexModel : ModelBase
    {
        public IEnumerable<StoryInfo> Stories { get; set; }

        public StoryIndexModel()
        {
        }
    }
}