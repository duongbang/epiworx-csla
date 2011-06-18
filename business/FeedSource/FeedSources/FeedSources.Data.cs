using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSources
    {
        private void Child_Fetch(FeedData parentData)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedSourceMemberDataFactory>();

                var data = dalFactory.Fetch(parentData);

                this.RaiseListChangedEvents = false;

                foreach (var item in data)
                {
                    this.Add(Csla.DataPortal.FetchChild<FeedSource>(item));
                }

                this.RaiseListChangedEvents = true;
            }
        }
    }
}
