using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Source
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        public SourceInfo ToSourceInfo()
        {
            var result = new SourceInfo();

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

        internal static Source NewSource(int sourceId, SourceType sourceTypeId)
        {
            return Csla.DataPortal.Create<Source>(
                new SourceDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceTypeId
                });
        }

        internal static Source FetchSource(int sourceId, SourceType sourceTypeId)
        {
            return Csla.DataPortal.Fetch<Source>(
                new SourceDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceTypeId
                });
        }

        internal static Source FetchSource(SourceData data)
        {
            var result = new Source();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteSource(int sourceId, SourceType sourceTypeId)
        {
            Csla.DataPortal.Delete<Source>(
                new SourceDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceTypeId
                });
        }
    }
}
