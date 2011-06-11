using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Feed
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Action);
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static Feed NewFeed()
        {
            return Csla.DataPortal.Create<Feed>();
        }

        internal static Feed FetchFeed(FeedDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Feed>(criteria);
        }

        internal static void DeleteFeed(FeedDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Feed>(criteria);
        }
    }
}
