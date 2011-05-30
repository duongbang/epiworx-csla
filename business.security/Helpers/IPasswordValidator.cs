using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business.Security.Helpers
{
    public interface IPasswordValidator
    {
        bool Validate(string password);
    }
}
