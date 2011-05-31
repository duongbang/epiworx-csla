using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class UserPasswordRepository
    {
        public static UserPassword UserPasswordFetch()
        {
            return UserPassword.FetchUserPassword(
                new UserPasswordDataCriteria
                {
                    UserId = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId
                });
        }

        public static UserPassword UserPasswordSave(UserPassword userPassword)
        {
            if (!userPassword.IsValid)
            {
                return userPassword;
            }

            UserPassword result;

            result = UserPasswordRepository.UserPasswordUpdate(userPassword);

            return result;
        }

        private static UserPassword UserPasswordUpdate(UserPassword userPassword)
        {
            userPassword = userPassword.Save();

            return userPassword;
        }
    }
}
