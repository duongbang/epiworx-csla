using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Week
    {
        public override string ToString()
        {
			return string.Format("{0:d} to {1:d}", this.StartDate, this.EndDate);
        }

        public WeekInfo ToWeekInfo()
        {
            var result = new WeekInfo();

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

        internal static Week NewWeek()
        {
            return Csla.DataPortal.Create<Week>();
        }

        internal static Week FetchWeek(WeekDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Week>(criteria);
        }

        internal static Week FetchWeek(WeekData data)
        {
            var result = new Week();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteWeek(WeekDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Week>(criteria);
        }
    }
}
