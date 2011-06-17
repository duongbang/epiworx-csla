using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business.Security
{
    public partial class BusinessIdentity
    {
        private void DataPortal_Fetch(BusinessIdentityDataCriteria criteria)
        {
            using (var dalManager = DataFactoryManager.GetManager())
            {
                var dalFactory = dalManager.GetProvider<IBusinessIdentityDataFactory>();

                var data = dalFactory.Fetch(criteria);

                if (data == null)
                {
                    throw new InvalidUserException();
                }

                if (!string.IsNullOrEmpty(criteria.Password))
                {
                    if (!PasswordHelper.ComparePasswords(data.Salt, criteria.Password, data.Password))
                    {
                        throw new InvalidPasswordException();
                    }
                }

                this.Fetch(data);
            }
        }

        protected void Fetch(BusinessIdentityData data)
        {
            this.UserId = data.UserId;
            this.Email = data.Email;
            this.FullName = data.FullName;
            this.Name = data.Name;
            this.IsAuthenticated = true;

            // this.Projects = data.Projects
            //    .Select(project => Csla.DataPortal.FetchChild<BusinessIdentityProject>(project)).ToList();
        }
    }
}
