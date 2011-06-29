using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Week
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {
                this.StartDate = DateTime.MaxValue.Date;
                this.EndDate = DateTime.MaxValue.Date;
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate = DateTime.Now;
            }

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(WeekDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IWeekDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(WeekData data)
        {
            this.WeekId = data.WeekId;
            this.EndDate = data.EndDate;
            this.Period = data.Period;
            this.StartDate = data.StartDate;
            this.Year = data.Year;
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
                var dalFactory = dalManager.GetProvider<IWeekDataFactory>();

                var data = new WeekData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.WeekId = data.WeekId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(WeekData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IWeekDataFactory>();

                var data = new WeekData();

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

        protected void Update(WeekData data)
        {
            data.WeekId = this.WeekId;
            data.EndDate = this.EndDate;
            data.Period = this.Period;
            data.StartDate = this.StartDate;
            data.Year = this.Year;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
            data.ModifiedBy = this.ModifiedBy;
            data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(WeekDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IWeekDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IWeekDataFactory>();

                dalFactory.Delete(
                    new WeekDataCriteria
                    {
                        WeekId = this.WeekId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}