using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Organization
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {
                this.IsActive = true;
                this.IsArchived = false;
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate = DateTime.Now;
            }

            // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertType>();

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(OrganizationDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(OrganizationData data)
        {
            this.OrganizationId = data.OrganizationId;
            this.Name = data.Name;
            this.Description = data.Description;
            this.IsActive = data.IsActive;
            this.IsArchived = data.IsArchived;
            this.ModifiedBy = data.ModifiedBy;
            this.ModifiedByName = data.ModifiedByUser.Name;
            this.ModifiedDate = data.ModifiedDate;
            this.CreatedBy = data.CreatedBy;
            this.CreatedByName = data.CreatedByUser.Name;
            this.CreatedDate = data.CreatedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationDataFactory>();

                var data = new OrganizationData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.OrganizationId = data.OrganizationId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(OrganizationData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationDataFactory>();

                var data = new OrganizationData();

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

        protected void Update(OrganizationData data)
        {
            data.OrganizationId = this.OrganizationId;
            data.Name = this.Name;
            data.Description = this.Description;
            data.IsActive = this.IsActive;
            data.IsArchived = this.IsArchived;
            data.ModifiedBy = this.ModifiedBy;
            data.ModifiedDate = this.ModifiedDate;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(OrganizationDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationDataFactory>();

                dalFactory.Delete(
                    new OrganizationDataCriteria
                    {
                        OrganizationId = this.OrganizationId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}