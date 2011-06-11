using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class StoryInfoList
    {
        private void DataPortal_Fetch(StoryDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IStoryDataFactory>();

                var data = dalFactory.FetchInfoList(criteria);

                this.RaiseListChangedEvents = false;
                this.IsReadOnly = false;

                this.AddRange(data.Select(row => Csla.DataPortal.FetchChild<StoryInfo>(row)));

                this.IsReadOnly = true;
                this.RaiseListChangedEvents = true;
            }
        }
    }
}
