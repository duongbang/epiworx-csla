using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Project : ISource
    {
        public int SourceId
        {
            get { return this.ProjectId; }
        }

        public SourceType SourceType
        {
            get { return SourceType.Project; }
        }

        public string SourceName
        {
            get { return this.Name; }
        }
    }
}
