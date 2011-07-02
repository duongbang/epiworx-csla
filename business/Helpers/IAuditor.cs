using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Epiworx.Business.Helpers
{
    public interface IAuditor<T>
    {
        T Object { get; }
        string Audit(T objectToCompare);
    }
}
