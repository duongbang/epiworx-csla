using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class OrganizationUser
    {
        [Csla.RunLocal]
        protected void DataPortal_Create(OrganizationUserMemberDataCriteria criteria)
        {
            using (this.BypassPropertyChecks)
            {
                this.OrganizationId = criteria.OrganizationId ?? 0;
                this.UserId = criteria.UserId ?? 0;
                this.ModifiedDate = DateTime.Now;
                this.CreatedDate = DateTime.Now;
            }

            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(OrganizationUserMemberDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationUserMemberDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                // this.ChildPropertyName = Csla.DataPortal.FetchChild<ChildPropertType>(data);
            }
        }

        protected void Fetch(OrganizationUserMemberData data)
        {
            this.OrganizationUserMemberId = data.OrganizationUserMemberId;
            this.OrganizationId = data.OrganizationId;
            this.OrganizationName = data.Organization.Name;
            this.RoleId = data.RoleId;
            this.UserId = data.UserId;
            this.UserEmail = data.User.Email;
            this.UserName = data.User.Name;
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
                var dalFactory = dalManager.GetProvider<IOrganizationUserMemberDataFactory>();

                var data = new OrganizationUserMemberData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedBy = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;
                    this.ModifiedDate = DateTime.Now;
                    this.CreatedBy = this.ModifiedBy;
                    this.CreatedDate = this.ModifiedDate;

                    this.Insert(data);

                    data = dalFactory.Insert(data);

                    this.OrganizationUserMemberId = data.OrganizationUserMemberId;
                }

                // this.FieldManager.UpdateChildren(data);
            }
        }

        protected void Insert(OrganizationUserMemberData data)
        {
            this.Update(data);
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationUserMemberDataFactory>();

                var data = new OrganizationUserMemberData();

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

        protected void Update(OrganizationUserMemberData data)
        {
            data.OrganizationUserMemberId = this.OrganizationUserMemberId;
            data.OrganizationId = this.OrganizationId;
            data.RoleId = this.RoleId;
            data.UserId = this.UserId;
            data.CreatedBy = this.CreatedBy;
            data.CreatedDate = this.CreatedDate;
            data.ModifiedBy = this.ModifiedBy;
            data.ModifiedDate = this.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(OrganizationUserMemberDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationUserMemberDataFactory>();

                dalFactory.Delete(criteria);
            }
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IOrganizationUserMemberDataFactory>();

                dalFactory.Delete(
                    new OrganizationUserMemberDataCriteria
                    {
                        OrganizationUserMemberId = this.OrganizationUserMemberId
                    });

                // this.ChildPropertyName = Csla.DataPortal.CreateChild<ChildPropertyType>();
            }
        }
    }
}