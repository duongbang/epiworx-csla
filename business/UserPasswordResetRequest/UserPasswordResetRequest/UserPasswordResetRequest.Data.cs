using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserPasswordResetRequest
    {
        private void DataPortal_Fetch(UserPasswordResetRequestDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserPasswordResetRequestDataFactory>();

                var data = dalFactory.Fetch(criteria);

                using (this.BypassPropertyChecks)
                {
                    this.Fetch(data);
                }
            }
        }

        protected void Fetch(UserPasswordResetRequestData data)
        {
            this.Email = data.Email;
            this.Token = data.Token;
            this.TokenExpirationDate = data.TokenExpirationDate;
        }

        [Csla.Transactional(Csla.TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IUserPasswordResetRequestDataFactory>();

                var data = new UserPasswordResetRequestData();

                using (this.BypassPropertyChecks)
                {
                    this.Update(data);

                    data = dalFactory.Update(data);

                    this.Success = true;
                }
            }
        }

        protected void Update(UserPasswordResetRequestData data)
        {
            data.Email = this.Email;
            data.Token = this.Token;
            data.TokenExpirationDate = this.TokenExpirationDate;
        }
    }
}