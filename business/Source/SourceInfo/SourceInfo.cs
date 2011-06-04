using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class SourceInfo : Csla.ReadOnlyBase<SourceInfo>, ISource
    {
        internal SourceInfo()
        {
        }
    }
}
