using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Note
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate = DateTime.Now;
            }

            // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertType>();

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(NoteDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<INoteDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(NoteData data)
        {
            this.NoteId = data.NoteId;
            this.Body = data.Body;
            this.IsArchived = data.IsArchived;
            this.SourceId = data.SourceId;
            this.SourceName = data.Source.Name;
            this.SourceTypeId = data.SourceTypeId;
            this.SourceTypeName = data.SourceType.Name;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<INoteDataFactory>();

                var data = new NoteData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.NoteId = data.NoteId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(NoteData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<INoteDataFactory>();

                var data = new NoteData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;

                    this.Update(data);

                    data = dalFactory.Update(data);
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Update(NoteData data)
        {
            data.NoteId = this.NoteId;
            data.Body = this.Body;
            data.IsArchived = this.IsArchived;
            data.SourceId = this.SourceId;
            data.SourceTypeId = this.SourceTypeId;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
            data.ModifiedBy = this.ModifiedBy;
            data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(NoteDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<INoteDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<INoteDataFactory>();

                dalFactory.Delete(
                    new NoteDataCriteria
                    {
                        NoteId = this.NoteId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}