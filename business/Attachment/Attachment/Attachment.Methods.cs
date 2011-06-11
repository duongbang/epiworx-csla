using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Attachment
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Name);
        }

        public AttachmentInfo ToAttachmentInfo()
        {
            var result = new AttachmentInfo();

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

        internal static Attachment NewAttachment()
        {
            return Csla.DataPortal.Create<Attachment>();
        }

        internal static Attachment FetchAttachment(AttachmentDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Attachment>(criteria);
        }

        internal static Attachment FetchAttachment(AttachmentData data)
        {
            var result = new Attachment();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteAttachment(AttachmentDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Attachment>(criteria);
        }
    }
}
