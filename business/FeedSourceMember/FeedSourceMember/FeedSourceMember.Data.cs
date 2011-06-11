using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSourceMember
    {
        [Csla.RunLocal]
        private void Child_Create(FeedSourceMemberDataCriteria criteria)
        {
            using (this.BypassPropertyChecks)
            {
                this.SourceId = criteria.SourceId ?? 0;
                this.SourceTypeId = criteria.SourceTypeId ?? 0;
                this.CreatedDate = DateTime.Now;
            }

            base.Child_Create();
        }

        private void Child_Fetch(FeedSourceMemberData data)
        {
            this.Fetch(data);
        }

        protected void Fetch(FeedSourceMemberData data)
        {
            using (this.BypassPropertyChecks)
            {
                this.FeedSourceMemberId = data.FeedSourceMemberId;
                this.FeedId = data.FeedId;
                this.SourceId = data.SourceId;
                this.SourceTypeId = data.SourceTypeId;
                this.SourceName = data.Source.Name;
                this.CreatedBy = data.CreatedBy;
                this.CreatedByName = data.CreatedByUser.Name;
                this.CreatedDate = data.CreatedDate;
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected void Child_Insert(FeedData parentData)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedSourceMemberDataFactory>();

                var data = new FeedSourceMemberData();

                using (this.BypassPropertyChecks)
                {
                    this.FeedId = parentData.FeedId;
                    this.CreatedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.CreatedDate = DateTime.Now;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.FeedSourceMemberId = data.FeedSourceMemberId;
                }
            }
        }

        protected void Insert(FeedSourceMemberData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected void Child_Update(FeedData parent)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedSourceMemberDataFactory>();

                var data = new FeedSourceMemberData();

                using (this.BypassPropertyChecks)
                {
                    this.Update(data);

                    data = dalFactory.Update(data);
                }
            }
        }

        protected void Update(FeedSourceMemberData data)
        {
            data.FeedSourceMemberId = this.FeedSourceMemberId;
            data.FeedId = this.FeedId;
            data.SourceId = this.SourceId;
            data.SourceTypeId = this.SourceTypeId;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected void Child_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IFeedSourceMemberDataFactory>();

                dalFactory.Delete(
                    new FeedSourceMemberDataCriteria
                    {
                        FeedSourceMemberId = this.FeedSourceMemberId
                    });
            }
        }
    }
}