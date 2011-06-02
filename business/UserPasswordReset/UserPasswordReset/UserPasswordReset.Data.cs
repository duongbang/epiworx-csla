using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserPasswordReset
    {
        private void DataPortal_Fetch(UserPasswordResetDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserPasswordResetDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }

                this.BusinessRules.CheckRules(); // We initialized the field values to empty so we need to force the rules to check
            }
        }

        protected void Fetch(UserPasswordResetData data)
        {
            this.UserId = data.UserId;
            this.Email = data.Email;
            this.Password = string.Empty;
            this.PasswordConfirmation = string.Empty;
            this.Token = data.Token;
            this.TokenExpirationDate = data.TokenExpirationDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserPasswordResetDataFactory>();

                var data = new UserPasswordResetData();

                using (this.BypassPropertyChecks)
                {
                    this.Update(data);

                    data = dalFactory.Update(data);
                }
            }
        }

        protected void Update(UserPasswordResetData data)
        {
            data.UserId = this.UserId;
            data.Email = this.Email;
            data.Salt = PasswordHelper.GetSalt(Settings.SaltSize);
            data.Password = PasswordHelper.Salt(data.Salt, this.Password);
            data.Token = string.Empty;
            data.TokenExpirationDate = DateTime.MaxValue;
        }
    }
}