using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class BusinessIdentityDataFactory : IBusinessIdentityDataFactory
    {
        public BusinessIdentityData Fetch(BusinessIdentityDataCriteria criteria)
        {
            var user = MockDb.Users
                .Where(row => row.Name == criteria.Name)
                .Single();

            var result = new BusinessIdentityData();

            result.UserId = user.UserId;
            result.Email = user.Email;
            result.Name = user.Name;
            result.FullName = user.FullName;
            result.Password = user.Password;
            result.Salt = user.Salt;

            return result;
        }
    }
}
