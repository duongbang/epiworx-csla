using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using Epiworx.Data;

namespace Epiworx.Business.Security
{
    public partial class BusinessIdentity
    {
        public static BusinessIdentity GetCurrentIdentity()
        {
            return (BusinessIdentity)Csla.ApplicationContext.User.Identity;
        }

        internal static BusinessIdentity GetIdentity(string name)
        {
            return Csla.DataPortal.Fetch<BusinessIdentity>(
                new BusinessIdentityDataCriteria
                    {
                        Name = name
                    });
        }

        internal static BusinessIdentity GetIdentity(string name, string password)
        {
            return Csla.DataPortal.Fetch<BusinessIdentity>(
                new BusinessIdentityDataCriteria
                    {
                        Name = name,
                        Password = password
                    });
        }
    }
}
