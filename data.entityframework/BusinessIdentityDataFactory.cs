using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class BusinessIdentityDataFactory : IBusinessIdentityDataFactory
    {
        public BusinessIdentityData Fetch(BusinessIdentityDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                              .GetManager(Database.SecurityConnection, false))
            {
                IQueryable<User> query = ctx.ObjectContext.Users;

                query = query.Where(row => row.Name == criteria.Name);

                var users = query.Select(row => row);

                if (users.Count() == 0)
                {
                    return null;
                }

                var user = users.Single();

                var data = new BusinessIdentityData();

                this.Fetch(user, data);

                return data;
            }
        }

        protected void Fetch(User user, BusinessIdentityData data)
        {
            data.UserId = user.UserId;
            data.Name = user.Name;
            data.Salt = user.Salt;
            data.Password = user.Password;
        }
    }
}
