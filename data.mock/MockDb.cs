using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public static class MockDb
    {
        public static List<ProjectData> Projects { get; private set; }
        public static List<ProjectUserMemberData> ProjectUserMembers { get; private set; }
        public static List<SprintData> Sprints { get; private set; }
        public static List<UserData> Users { get; private set; }

        static MockDb()
        {
            #region Projects

            Projects = new List<ProjectData>();

            #endregion

            #region ProjectUserMembers

            ProjectUserMembers = new List<ProjectUserMemberData>();

            #endregion

            #region Sprints

            Sprints = new List<SprintData>();

            #endregion

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
