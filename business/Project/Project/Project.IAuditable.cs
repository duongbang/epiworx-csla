using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class Project : IAuditable<Project>
    {
        public IAuditor<Project> Auditor { get; set; }
    }
}
