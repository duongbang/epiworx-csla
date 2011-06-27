using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class SprintFormModel : ModelBase
    {
        public Sprint Sprint { get; set; }
        public IEnumerable<StatusInfo> Statuses { get; set; }
        public IEnumerable<ProjectUserInfo> Users { get; set; }
        public IEnumerable<StoryInfo> Stories { get; set; }
        public IEnumerable<NoteInfo> Notes { get; set; }
        public IEnumerable<AttachmentInfo> Attachments { get; set; }

        public SprintFormModel()
        {
        }
    }
}