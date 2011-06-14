using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class UserPasswordResetRequestDataFactory : IUserPasswordResetRequestDataFactory
    {
        public UserPasswordResetRequestData Fetch(UserPasswordResetRequestDataCriteria criteria)
        {
            var data = MockDb.Users
                .Where(row => row.Email == criteria.Email)
                .SingleOrDefault();

            var result = new UserPasswordResetRequestData();

            result.Email = data.Email;
            result.Token = data.Token;
            result.TokenExpirationDate = data.TokenExpirationDate;

            return result;
        }

        public UserPasswordResetRequestData Update(UserPasswordResetRequestData data)
        {
            var user = MockDb.Users
                .Where(row => row.Email == data.Email)
                .SingleOrDefault();

            user.Token = data.Token;
            user.TokenExpirationDate = data.TokenExpirationDate;

            return data;
        }
    }
}
