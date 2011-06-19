using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Source
    {
        [Csla.RunLocal]
        protected void DataPortal_Create(SourceDataCriteria criteria)
        {
            using (this.BypassPropertyChecks)
            {
                this.SourceId = criteria.SourceId ?? 0;
                this.SourceTypeId = criteria.SourceTypeId ?? 0;
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate = DateTime.Now;
            }

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(SourceDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISourceDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(SourceData data)
        {
            this.SourceId = data.SourceId;
            this.SourceTypeId = data.SourceTypeId;
            this.Name = data.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedDate = data.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISourceDataFactory>();

                var data = new SourceData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.SourceId = data.SourceId;
                    this.SourceTypeId = data.SourceTypeId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(SourceData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISourceDataFactory>();

                var data = new SourceData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedDate = DateTime.Now;

                    this.Update(data);

                    data = dalFactory.Update(data);
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Update(SourceData data)
        {
            data.SourceId = this.SourceId;
            data.SourceTypeId = this.SourceTypeId;
            data.Name = this.Name;
            data.CreatedDate = this.CreatedDate;
            data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SourceDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISourceDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISourceDataFactory>();

                dalFactory.Delete(
                    new SourceDataCriteria
                    {
                        SourceId = this.SourceId,
                        SourceTypeId = this.SourceTypeId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}