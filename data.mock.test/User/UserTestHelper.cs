using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Test.Helpers;

namespace Epiworx.Test.Helpers
{
    public class UserTestHelper
    {
        public static User UserAdd()
        {
            var user = UserTestHelper.UserNew();

            user = UserRepository.UserSave(user);

            return user;
        }

        public static User UserNew()
        {
            var user = UserRepository.UserNew();

            user.Email = DataHelper.RandomEmail();
            user.FullName = DataHelper.RandomString(50);
            user.Name = DataHelper.RandomString(30);

            user.SetPassword(DataHelper.RandomPassword(20));

            return user;
        }
    }
}
