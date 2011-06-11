using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ISource
    {
        int SourceId { get; }
        SourceType SourceType { get; }
        string SourceName { get; }
    }
}
