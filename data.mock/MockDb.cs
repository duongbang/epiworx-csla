using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public static class MockDb
    {
        public static List<UserData> Users { get; private set; }

        static MockDb()
        {
            #region Users

            Users =
                    new List<UserData>
                    {
                        new UserData
                            {
                                UserId = 1,
                                Name = "Administrator",
                                Email = "administrator@website.com",
                                FullName = "Administrator",
                                Salt = "YQmsBzX/4A",
                                Password = "D/M0RmZPjxvVpgrZ6QnOmB4EYag=",
                                IsActive = true,
                                CreatedDate = DateTime.Parse("1/1/2011"),
                                ModifiedDate = DateTime.Parse("1/1/2011")
                            },
                        new UserData
                            {
                                UserId = 2,
                                Name = "User",
                                Email = "user@website.com",
                                FullName = "User",
                                Salt = "YQmsBzX/4A",
                                Password = "D/M0RmZPjxvVpgrZ6QnOmB4EYag=",
                                IsActive = true,
                                CreatedDate = DateTime.Parse("1/1/2011"),
                                ModifiedDate = DateTime.Parse("1/1/2011")
                            }
                    };

            #endregion
        }
    }
}
