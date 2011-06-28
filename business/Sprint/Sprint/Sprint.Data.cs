using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Sprint
    {
        [Csla.RunLocal]
        protected void DataPortal_Create(SprintDataCriteria criteria)
        {
            using (this.BypassPropertyChecks)
            {
                this.CompletedDate = DateTime.MaxValue.Date;
                this.IsActive = true;
                this.EstimatedCompletedDate = DateTime.MaxValue.Date;
                this.ProjectId = criteria.ProjectId ?? 0;
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate = DateTime.Now;
            }

            this.PropertyHasChanged(ProjectIdProperty);

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(SprintDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISprintDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(SprintData data)
        {
            this.SprintId = data.SprintId;
            this.CompletedDate = data.CompletedDate;
            this.Description = data.Description;
            this.IsActive = data.IsActive;
            this.IsArchived = data.IsArchived;
            this.IsCompleted = data.IsCompleted;
            this.Duration = data.Duration;
            this.EstimatedCompletedDate = data.EstimatedCompletedDate;
            this.EstimatedDuration = data.EstimatedDuration;
            this.Name = data.Name;
            this.ProjectId = data.ProjectId;
            this.ProjectName = data.Project.Name;
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
                var dalFactory = dalManager.GetProvider<ISprintDataFactory>();

                var data = new SprintData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.SprintId = data.SprintId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(SprintData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISprintDataFactory>();

                var data = new SprintData();

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

        protected void Update(SprintData data)
        {
            data.SprintId = this.SprintId;
            data.CompletedDate = this.CompletedDate;
            data.Description = this.Description;
            data.IsActive = this.IsActive;
            data.IsArchived = this.IsArchived;
            data.IsCompleted = this.IsCompleted;
            data.Duration = this.Duration;
            data.EstimatedCompletedDate = this.EstimatedCompletedDate;
            data.EstimatedDuration = this.EstimatedDuration;
            data.Name = this.Name;
            data.ProjectId = this.ProjectId;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
            data.ModifiedBy = this.ModifiedBy;
            data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SprintDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISprintDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<ISprintDataFactory>();

                dalFactory.Delete(
                    new SprintDataCriteria
                    {
                        SprintId = this.SprintId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}