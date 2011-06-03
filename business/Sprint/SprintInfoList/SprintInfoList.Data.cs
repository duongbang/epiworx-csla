using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class SprintInfoList
    {
        private void DataPortal_Fetch(SprintDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISprintDataFactory>();

                var data = dalFactory.FetchInfoList(criteria);

                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                this.AddRange(data.Select(row => Csla.DataPortal.FetchChild<SprintInfo>(row)));

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
