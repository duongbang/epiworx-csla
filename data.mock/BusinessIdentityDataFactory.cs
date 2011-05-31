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
            var data = MockDb.Users
                .Where(row => row.Name == criteria.Name)
                .Single();

            var result = new BusinessIdentityData();

            result.UserId = data.UserId;
            result.Email = data.Email;
            result.Name = data.Name;
            result.FullName = data.FullName;
            result.Password = data.Password;
            result.Salt = data.Salt;

            return result;
        }
    }
}
