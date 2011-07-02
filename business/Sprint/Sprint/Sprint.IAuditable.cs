using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class Sprint : IAuditable<Sprint>
    {
        public IAuditor<Sprint> Auditor { get; set; }
    }
}
