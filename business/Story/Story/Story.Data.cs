using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Story
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {
                this.AssignedDate = DateTime.MaxValue;
                this.CompletedDate = DateTime.MaxValue;
                this.CreatedDate = DateTime.Now;
                this.EstimatedCompletedDate = DateTime.MaxValue;
                this.StartDate = DateTime.MaxValue;
                this.ModifiedDate = DateTime.Now;
            }

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(StoryDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IStoryDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(StoryData data)
        {
            this.StoryId = data.StoryId;
            this.AssignedTo = data.AssignedTo;
            this.AssignedToEmail = data.AssignedToUser.Email;
            this.AssignedToName = data.AssignedToUser.Name;
            this.AssignedDate = data.AssignedDate;
            this.CompletedDate = data.CompletedDate;
            this.Description = data.Description;
            this.Duration = data.Duration;
            this.EstimatedCompletedDate = data.EstimatedCompletedDate;
            this.EstimatedDuration = data.EstimatedDuration;
            this.IsArchived = data.IsArchived;
            this.IsCompleted = data.IsCompleted;
            this.IsOpened = data.IsOpened;
            this.ProjectId = data.ProjectId;
            this.ProjectName = data.Project.Name;
            this.SprintId = data.SprintId;
            this.SprintName = data.Sprint.Name;
            this.StartDate = data.StartDate;
            this.StatusId = data.StatusId;
            this.StatusName = data.Status.Name;
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
                var dalFactory = dalManager.GetProvider<IStoryDataFactory>();

                var data = new StoryData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.StoryId = data.StoryId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(StoryData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IStoryDataFactory>();

                var data = new StoryData();

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

        protected void Update(StoryData data)
        {
            data.StoryId = this.StoryId;
            data.AssignedTo = this.AssignedTo;
            data.AssignedDate = this.AssignedDate;
            data.CompletedDate = this.CompletedDate;
            data.Description = this.Description;
            data.Duration = this.Duration;
            data.EstimatedCompletedDate = this.EstimatedCompletedDate;
            data.EstimatedDuration = this.EstimatedDuration;
            data.IsArchived = this.IsArchived;
            data.IsCompleted = this.IsCompleted;
            data.ProjectId = this.ProjectId;
            data.SprintId = this.SprintId;
            data.StartDate = this.StartDate;
            data.StatusId = this.StatusId;
            data.ModifiedBy = this.ModifiedBy;
            data.ModifiedDate = this.ModifiedDate;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(StoryDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IStoryDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IStoryDataFactory>();

                dalFactory.Delete(
                    new StoryDataCriteria
                    {
                        StoryId = this.StoryId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}