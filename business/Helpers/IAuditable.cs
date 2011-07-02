using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business.Helpers
{
    public interface IAuditable<T>
    {
        IAuditor<T> Auditor { get; set; }
    }
}
