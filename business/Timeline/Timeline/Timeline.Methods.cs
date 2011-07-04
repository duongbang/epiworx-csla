using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Timeline
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Body);
        }

        public TimelineInfo ToTimelineInfo()
        {
            var result = new TimelineInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
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

        internal static Timeline NewTimeline()
        {
            return Csla.DataPortal.Create<Timeline>();
        }

        internal static Timeline FetchTimeline(TimelineDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Timeline>(criteria);
        }

        internal static Timeline FetchTimeline(TimelineData data)
        {
            var result = new Timeline();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteTimeline(TimelineDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Timeline>(criteria);
        }
    }
}
