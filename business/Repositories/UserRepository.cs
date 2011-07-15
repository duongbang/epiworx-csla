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
    public class UserRepository
    {
        public static User UserFetch()
        {
            return User.FetchUser(
                new UserDataCriteria
                {
                    UserId = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId
                });
        }

        public static User UserFetch(int userId)
        {
            return User.FetchUser(
                new UserDataCriteria
                {
                    UserId = userId
                });
        }

        public static User UserFetch(string name)
        {
            return User.FetchUser(
                new UserDataCriteria
                {
                    Name = name
                });
        }

        public static UserInfoList UserFetchInfoList()
        {
            return UserRepository.UserFetchInfoList(
                new UserDataCriteria());
        }

        public static UserInfoList UserFetchInfoList(IEnumerable<IProject> projects)
        {
            return UserRepository.UserFetchInfoList(
                new UserDataCriteria
                    {
                        ProjectId = projects.Select(row => row.ProjectId).ToArray()
                    });
        }

        public static UserInfoList UserFetchInfoList(UserDataCriteria criteria)
        {
            return UserInfoList.FetchUserInfoList(criteria);
        }

        public static User UserSave(User user)
        {
            if (!user.IsValid)
            {
                return user;
            }

            User result;

            if (user.IsNew)
            {
                result = UserRepository.UserInsert(user);
            }
            else
            {
                result = UserRepository.UserUpdate(user);
            }

            return result;
        }

        private static User UserInsert(User user)
        {
            user = user.Save();

            SourceRepository.SourceAdd(user.UserId, SourceType.User, user.Name);

            return user;
        }

        private static User UserUpdate(User user)
        {
            if (!user.IsDirty)
            {
                return user;
            }

            user = user.Save();

            SourceRepository.SourceUpdate(user.UserId, SourceType.User, user.Name);

            return user;
        }

        public static User UserNew()
        {
            var user = User.NewUser();

            return user;
        }
    }
}
