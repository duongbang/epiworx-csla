using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class FeedSourceMemberInfo : Csla.ReadOnlyBase<FeedSourceMemberInfo>, IFeedSourceMember
    {
        internal FeedSourceMemberInfo()
        {
        }
    }
}
