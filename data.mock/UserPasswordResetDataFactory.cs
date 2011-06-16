using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class UserPasswordResetDataFactory : IUserPasswordResetDataFactory
    {
        public UserPasswordResetData Fetch(UserPasswordResetDataCriteria criteria)
        {
            var data = MockDb.Users
                .Where(row => row.Token == criteria.Token)
                .Single();

            var result = new UserPasswordResetData();

            result.UserId = data.UserId;
            result.Email = data.Email;
            result.Token = data.Token;
            result.TokenExpirationDate = data.TokenExpirationDate;

            return result;
        }

        public UserPasswordResetData Update(UserPasswordResetData data)
        {
            var user = MockDb.Users
                .Where(row => row.UserId == data.UserId)
                .Single();

            user.Password = data.Password;
            user.Salt = data.Salt;
            user.Token = data.Token;
            user.TokenExpirationDate = data.TokenExpirationDate;

            return data;
        }
    }
}
