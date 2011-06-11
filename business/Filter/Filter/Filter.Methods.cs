using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Filter
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Name);
        }

        public FilterInfo ToFilterInfo()
        {
            var result = new FilterInfo();

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

        internal static Filter NewFilter()
        {
            return Csla.DataPortal.Create<Filter>();
        }

        internal static Filter FetchFilter(FilterDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Filter>(criteria);
        }

        internal static Filter FetchFilter(FilterData data)
        {
            var result = new Filter();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteFilter(FilterDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Filter>(criteria);
        }
    }
}
