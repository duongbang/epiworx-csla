using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class AttachmentInfoList
    {
        private void DataPortal_Fetch(AttachmentDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IAttachmentDataFactory>();

                var data = dalFactory.FetchInfoList(criteria);

                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                this.AddRange(data.Select(row => Csla.DataPortal.FetchChild<AttachmentInfo>(row)));

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
