using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class Story : IAuditable<Story>
    {
        public IAuditor<Story> Auditor { get; set; }
    }
}
