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
    public class UserPasswordResetRepository
    {
        public static UserPasswordReset UserPasswordResetFetch(string token)
        {
            return UserPasswordReset.FetchUserPasswordReset(
                new UserPasswordResetDataCriteria
                {
                    Token = token
                });
        }

        public static UserPasswordReset UserPasswordResetSave(UserPasswordReset userPasswordReset)
        {
            if (!userPasswordReset.IsValid)
            {
                return userPasswordReset;
            }

            UserPasswordReset result;

            result = UserPasswordResetRepository.UserPasswordResetUpdate(userPasswordReset);

            return result;
        }

        private static UserPasswordReset UserPasswordResetUpdate(UserPasswordReset userPasswordReset)
        {
            userPasswordReset = userPasswordReset.Save();

            return userPasswordReset;
        }
    }
}
