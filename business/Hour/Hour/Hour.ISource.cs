using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Hour : ISource
    {
        public int SourceId
        {
            get { return this.HourId; }
        }

        public SourceType SourceType
        {
            get { return SourceType.Hour; }
        }

        public string SourceName
        {
            get { return this.Date.ToShortDateString(); }
        }
    }
}
