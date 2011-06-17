using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Category
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {              
                this.IsActive = true;
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate =  DateTime.Now;
            }

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(CategoryDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ICategoryDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(CategoryData data)
        {
		    this.CategoryId = data.CategoryId;
		    this.Description = data.Description;
		    this.IsActive = data.IsActive;
		    this.IsArchived = data.IsArchived;
		    this.Name = data.Name;
		    this.Ordinal = data.Ordinal;
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
                var dalFactory = dalManager.GetProvider<ICategoryDataFactory>();

                var data = new CategoryData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.CategoryId = data.CategoryId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(CategoryData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ICategoryDataFactory>();

                var data = new CategoryData();

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

        protected void Update(CategoryData data)
        {
		    data.CategoryId = this.CategoryId;
		    data.Description = this.Description;
		    data.IsActive = this.IsActive;
		    data.IsArchived = this.IsArchived;
		    data.Name = this.Name;
		    data.Ordinal = this.Ordinal;
		    data.CreatedBy = this.CreatedBy;
		    data.CreatedDate = this.CreatedDate;
		    data.ModifiedBy = this.ModifiedBy;
		    data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(CategoryDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ICategoryDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ICategoryDataFactory>();

                dalFactory.Delete(
                    new CategoryDataCriteria
                    {
                        CategoryId = this.CategoryId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}