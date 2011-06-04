using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Status
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Name);
        }

        public StatusInfo ToStatusInfo()
        {
            var result = new StatusInfo();

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

        internal static Status NewStatus()
        {
            return Csla.DataPortal.Create<Status>();
        }

        internal static Status FetchStatus(StatusDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Status>(criteria);
        }

        internal static Status FetchStatus(StatusData data)
        {
            var result = new Status();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteStatus(StatusDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Status>(criteria);
        }
    }
}
