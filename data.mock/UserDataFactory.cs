using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class UserDataFactory : IUserDataFactory
    {
        public UserData Fetch(UserDataCriteria criteria)
        {
            var data = MockDb.Users
                .Where(row => row.UserId == criteria.UserId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public UserData Fetch(UserData data)
        {
            return data;
        }

        public UserData[] FetchInfoList(UserDataCriteria criteria)
        {
            var query = MockDb.Users
                .AsQueryable();

            if (criteria.Email != null)
            {
                query = query.Where(row => row.Email == criteria.Email);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.Token != null)
            {
                query = query.Where(row => row.Token == criteria.Token);
            }

            var users = query.AsQueryable();

            var data = new List<UserData>();

            foreach (var user in users)
            {
                data.Add(this.Fetch(user));
            }

            return data.ToArray();
        }

        public UserData[] FetchLookupInfoList(UserDataCriteria criteria)
        {
            var query = MockDb.Users
                .AsQueryable();

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.Email != null)
            {
                query = query.Where(row => row.Email == criteria.Email);
            }

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public UserData Create()
        {
            return new UserData();
        }

        public UserData Update(UserData data)
        {
            var user = MockDb.Users
                .Where(row => row.UserId == data.UserId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, user);

            return data;
        }

        public UserData Insert(UserData data)
        {
            if (MockDb.Users.Count() == 0)
            {
                data.UserId = 1;
            }
            else
            {
                data.UserId = MockDb.Users.Select(row => row.UserId).Max() + 1;
            }

            MockDb.Users.Add(data);

            return data;
        }

        public void Delete(UserDataCriteria criteria)
        {
            var data = MockDb.Users
                .Where(row => row.UserId == criteria.UserId)
                .SingleOrDefault();

            MockDb.Users.Remove(data);
        }
    }
}
