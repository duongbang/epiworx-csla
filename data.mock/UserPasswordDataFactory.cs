using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class UserPasswordDataFactory : IUserPasswordDataFactory
    {
        public UserPasswordData Fetch(UserPasswordDataCriteria criteria)
        {
            var data = MockDb.Users
                .Where(row => row.UserId == criteria.UserId)
                .SingleOrDefault();

            var result = new UserPasswordData();

            result.UserId = data.UserId;
            result.Password = data.Password;
            result.Salt = data.Salt;
            result.ModifiedDate = data.ModifiedDate;

            return result;
        }

        public UserPasswordData Update(UserPasswordData data)
        {
            var user = MockDb.Users
                .Where(row => row.UserId == data.UserId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, user);

            return data;
        }
    }
}
