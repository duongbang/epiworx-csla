using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Story : ISource
    {
        public int SourceId
        {
            get { return this.StoryId; }
        }

        public SourceType SourceType
        {
            get { return SourceType.Story; }
        }

        public string SourceName
        {
            get { return this.StoryId.ToString(); }
        }
    }
}
