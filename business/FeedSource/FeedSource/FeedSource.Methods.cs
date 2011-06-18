using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSource
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

        internal static FeedSource NewFeedSource(int sourceId, SourceType sourceTypeId)
        {
            return Csla.DataPortal.CreateChild<FeedSource>(
                new FeedSourceMemberDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceTypeId
                });
        }

        internal static FeedSource NewFeedSource(FeedSourceMemberDataCriteria criteria)
        {
            return Csla.DataPortal.CreateChild<FeedSource>(criteria);
        }

        internal static FeedSource FetchFeedSource(FeedSourceMemberDataCriteria criteria)
        {
            return Csla.DataPortal.FetchChild<FeedSource>(criteria);
        }
    }
}
