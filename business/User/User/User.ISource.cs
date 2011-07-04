using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class User : ISource
    {
        public int SourceId
        {
            get { return this.UserId; }
        }

        public SourceType SourceType
        {
            get { return SourceType.User; }
        }

        public string SourceName
        {
            get { return this.Name; }
        }
    }
}
