﻿using System;
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
    }
}