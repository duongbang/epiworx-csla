using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class User
    {
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            using (this.BypassPropertyChecks)
            {
                this.IsActive = true;
            }

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(UserDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(UserData data)
        {
            this.UserId = data.UserId;
            this.Email = data.Email;
            this.FullName = data.FullName;
            this.IsActive = data.IsActive;
            this.IsArchived = data.IsArchived;
            this.Name = data.Name;
            this.Salt = data.Salt;
            this.Password = data.Password;
            this.CreatedDate = data.CreatedDate;
            this.ModifiedDate = data.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserDataFactory>();

                var data = new UserData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.UserId = data.UserId;
                }

                this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(UserData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserDataFactory>();

                var data = new UserData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedDate = DateTime.Now;

                    this.Update(data);

                    data = dalFactory.Update(data);
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Update(UserData data)
        {
            data.UserId = this.UserId;
            data.Email = this.Email;
            data.FullName = this.FullName;
            data.IsActive = this.IsActive;
            data.IsArchived = this.IsArchived;
            data.Name = this.Name;
            data.Salt = this.Salt;
            data.Password = this.Password;
            data.CreatedDate = this.CreatedDate;
            data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(UserDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserDataFactory>();

                dalFactory.Delete(
                    new UserDataCriteria
                    {
                        UserId = this.UserId
                    });
            }
        }
    }
}