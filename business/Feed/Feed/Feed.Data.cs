using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Feed
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {
                this.CreatedDate = DateTime.Now;
            }

            this.Sources = Csla.DataPortal.CreateChild<FeedSourceMembers>();

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(FeedDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                this.Sources = Csla.DataPortal.FetchChild<FeedSourceMembers>(data);
            }
        }

        protected void Fetch(FeedData data)
        {
            this.FeedId = data.FeedId;
            this.Action = data.Action;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByEmail = data.CreatedByUser.Email;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedDataFactory>();

                var data = new FeedData();

                using (this.BypassPropertyChecks)
                {
                    this.CreatedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.CreatedDate = DateTime.Now;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.FeedId = data.FeedId;
                }

                this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(FeedData data)
        {
            this.Update(data);
        }

        protected void Update(FeedData data)
        {
            data.FeedId = this.FeedId;
            data.Action = this.Action;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(FeedDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedDataFactory>();

                dalFactory.Delete(
                    new FeedDataCriteria
                    {
                        FeedId = this.FeedId
                    });

                this.Sources = Csla.DataPortal.CreateChild<FeedSourceMembers>();
            }
        }
    }
}