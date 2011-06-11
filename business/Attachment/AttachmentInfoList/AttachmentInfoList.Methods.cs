using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class AttachmentInfoList
    {
        internal static AttachmentInfoList FetchAttachmentInfoList(AttachmentDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<AttachmentInfoList>(criteria);
        }
    }
}
