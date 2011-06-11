using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class FeedSourceMember : Csla.BusinessBase<FeedSourceMember>, IFeedSourceMember
    {
        private FeedSourceMember()
        {
        }
    }
}
