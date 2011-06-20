using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public enum Role
    {
        None = 0,
        Owner = 1,
        Administrator = 2,
        Editor = 3,
        Contributor = 4,
        Reviewer = 5
    }
}