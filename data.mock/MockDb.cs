using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public static class MockDb
    {
        public static List<AttachmentData> Attachments { get; private set; }
        public static List<CategoryData> Categories { get; private set; }
        public static List<FeedData> Feeds { get; private set; }
        public static List<FeedSourceMemberData> FeedSourceMembers { get; private set; }
        public static List<FilterData> Filters { get; private set; }
        public static List<NoteData> Notes { get; private set; }
        public static List<ProjectData> Projects { get; private set; }
        public static List<ProjectUserMemberData> ProjectUserMembers { get; private set; }
        public static List<SourceData> Sources { get; private set; }
        public static List<SourceTypeData> SourceTypes { get; private set; }
        public static List<SprintData> Sprints { get; private set; }
        public static List<StatusData> Statuses { get; private set; }
        public static List<StoryData> Stories { get; private set; }
        public static List<UserData> Users { get; private set; }

        static MockDb()
        {
            #region Attachments

            Attachments = new List<AttachmentData>();

            #endregion

            #region Categories

            Categories = new List<CategoryData>();

            #endregion

            #region Feeds

            Feeds = new List<FeedData>();

            #endregion

            #region FeedSourceMembers

            FeedSourceMembers = new List<FeedSourceMemberData>();

            #endregion

            #region Filters

            Filters = new List<FilterData>();

            #endregion

            #region Notes

            Notes = new List<NoteData>();

            #endregion

            #region Projects

            Projects = new List<ProjectData>();

            #endregion

            #region ProjectUserMembers

            ProjectUserMembers = new List<ProjectUserMemberData>();

            #endregion

            #region Sources

            Sources = new List<SourceData>();

            #endregion

            #region SourceTypes

            SourceTypes = new List<SourceTypeData>();

            #endregion

            #region Sprints

            Sprints = new List<SprintData>();

            #endregion

            #region Statuses

            Statuses = new List<StatusData>();

            #endregion

            #region Stories

            Stories = new List<StoryData>();

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
