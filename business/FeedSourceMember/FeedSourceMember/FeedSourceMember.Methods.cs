using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSourceMember
    {
        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static FeedSourceMember NewFeedSourceMember(int sourceId, SourceType sourceTypeId)
        {
            return Csla.DataPortal.CreateChild<FeedSourceMember>(
                new FeedSourceMemberDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceTypeId
                });
        }

        internal static FeedSourceMember NewFeedSourceMember(FeedSourceMemberDataCriteria criteria)
        {
            return Csla.DataPortal.CreateChild<FeedSourceMember>(criteria);
        }

        internal static FeedSourceMember FetchFeedSourceMember(FeedSourceMemberDataCriteria criteria)
        {
            return Csla.DataPortal.FetchChild<FeedSourceMember>(criteria);
        }
    }
}
