using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class NoteListModel : ModelBase
    {
        public int SourceId { get; set; }
        public int SourceTypeId { get; set; }
        public IEnumerable<NoteInfo> Notes { get; set; }
        public IEnumerable<AttachmentInfo> Attachments { get; set; }
    }
}