using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class Status : IAuditable<Status>
    {
        public IAuditor<Status> Auditor { get; set; }
    }
}
