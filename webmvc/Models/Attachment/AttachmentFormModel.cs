using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class AttachmentFormModel : ModelBase
    {
        public Attachment Attachment { get; set; }
    }
}