using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserPassword
    {
        private void DataPortal_Fetch(UserPasswordDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserPasswordDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }
            }
        }

        protected void Fetch(UserPasswordData data)
        {
            this.UserId = data.UserId;
            this.Password = data.Password;
            this.ModifiedDate = data.ModifiedDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserPasswordDataFactory>();

                var data = new UserPasswordData();

                using (this.BypassPropertyChecks)
                {
                    this.ModifiedDate = DateTime.Now;

                    this.Update(data);

                    data = dalFactory.Update(data);
                }
            }
        }

        protected void Update(UserPasswordData data)
        {
            data.UserId = this.UserId;
            data.Salt = PasswordHelper.GetSalt(User.SaltSize);
            data.Password = PasswordHelper.Salt(data.Salt, this.Password);
            data.ModifiedDate = this.ModifiedDate;
        }
    }
}