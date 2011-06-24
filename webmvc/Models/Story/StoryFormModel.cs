using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class StoryFormModel : ModelBase
    {
        public Story Story { get; set; }
        public IEnumerable<SprintInfo> Sprints { get; set; }
        public IEnumerable<StatusInfo> Statuses { get; set; }
        public IEnumerable<ProjectUserInfo> Users { get; set; }
        public IEnumerable<HourInfo> Hours { get; set; }
        public IEnumerable<NoteInfo> Notes { get; set; }
        public IEnumerable<AttachmentInfo> Attachments { get; set; }

        public StoryFormModel()
        {
            this.FindCategory = "Story";
        }
    }
}