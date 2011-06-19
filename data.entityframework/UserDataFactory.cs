using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class UserDataFactory : IUserDataFactory
    {
        public UserData Fetch(UserDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var user = this.Fetch(ctx, criteria)
                    .Single();

                var userData = new UserData();

                this.Fetch(user, userData);

                return userData;
            }
        }

        public UserData[] FetchInfoList(UserDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var users = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var userDataList = new List<UserData>();

                foreach (var user in users)
                {
                    var userData = new UserData();

                    this.Fetch(user, userData);

                    userDataList.Add(userData);
                }

                return userDataList.ToArray();
            }
        }

        public UserData[] FetchLookupInfoList(UserDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var users = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var userDataList = new List<UserData>();

                foreach (var user in users)
                {
                    var userData = new UserData();

                    this.Fetch(user, userData);

                    userDataList.Add(userData);
                }

                return userDataList.ToArray();
            }
        }

        public UserData Create()
        {
            return new UserData();
        }

        public UserData Update(UserData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var user =
                    new User
                    {
                        UserId = data.UserId
                    };

                ctx.ObjectContext.Users.Attach(user);

                Csla.Data.DataMapper.Map(data, user);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public UserData Insert(UserData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var user = new User();

                Csla.Data.DataMapper.Map(data, user);

                ctx.ObjectContext.AddToUsers(user);

                ctx.ObjectContext.SaveChanges();

                data.UserId = user.UserId;

                return data;
            }
        }

        public void Delete(UserDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var user = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Users.DeleteObject(user);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(User user, UserData userData)
        {
            Csla.Data.DataMapper.Map(user, userData);
        }

        private IQueryable<User> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             UserDataCriteria criteria)
        {
            IQueryable<User> query = ctx.ObjectContext.Users;

            if (criteria.UserId != null)
            {
                query = query.Where(row => row.UserId == criteria.UserId);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.Email != null)
            {
                query = query.Where(row => row.Email == criteria.Email);
            }

            if (criteria.Password != null)
            {
                query = query.Where(row => row.Password == criteria.Password);
            }

            if (criteria.Salt != null)
            {
                query = query.Where(row => row.Salt == criteria.Salt);
            }

            if (criteria.Token != null)
            {
                query = query.Where(row => row.Token == criteria.Token);
            }

            if (criteria.IsActive != null)
            {
                query = query.Where(row => row.IsActive == criteria.IsActive);
            }

            if (criteria.ModifiedDate != null && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null && criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.CreatedDate != null && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null && criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.Text != null)
            {
                query = query.Where(row => row.Name.Contains(criteria.Text)
                    || row.Email.Contains(criteria.Text));
            }

            if (criteria.SortBy != null)
            {
                query = query.OrderBy(string.Format(
                    "{0} {1}",
                    criteria.SortBy,
                    criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            if (criteria.SkipRecords != null)
            {
                query = query.Skip(criteria.SkipRecords.Value);
            }

            if (criteria.MaximumRecords != null)
            {
                query = query.Take(criteria.MaximumRecords.Value);
            }

            return query;
        }
    }
}
