﻿using System;
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

        public static User UserInsert(User user)
        {
            user = user.Save();

            return user;
        }

        public static User UserUpdate(User user)
        {
            user = user.Save();

            return user;
        }

        public static User UserNew()
        {
            var user = User.NewUser();

            return user;
        }

        public static bool UserDelete(User user)
        {
            User.DeleteUser(
                new UserDataCriteria
                {
                    UserId = user.UserId
                });

            return true;
        }

        public static bool UserDelete(int userId)
        {
            return UserRepository.UserDelete(
                UserRepository.UserFetch(userId));
        }
    }
}