using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    using System.Configuration;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;

    public static class MockDb
    {
        public static List<AttachmentData> Attachments { get; private set; }
        public static List<FeedData> Feeds { get; private set; }
        public static List<FeedSourceMemberData> FeedSourceMembers { get; private set; }
        public static List<FilterData> Filters { get; private set; }
        public static List<HourData> Hours { get; private set; }
        public static List<NoteData> Notes { get; private set; }
        public static List<ProjectData> Projects { get; private set; }
        public static List<ProjectUserMemberData> ProjectUserMembers { get; private set; }
        public static List<SourceData> Sources { get; private set; }
        public static List<SourceTypeData> SourceTypes { get; private set; }
        public static List<SprintData> Sprints { get; private set; }
        public static List<StatusData> Statuses { get; private set; }
        public static List<StoryData> Stories { get; private set; }
        public static List<TimelineData> Timelines { get; private set; }
        public static List<UserData> Users { get; private set; }

        static MockDb()
        {
            Attachments = new List<AttachmentData>();

            Feeds = new List<FeedData>();

            FeedSourceMembers = new List<FeedSourceMemberData>();

            Filters = new List<FilterData>();

            Hours = new List<HourData>();

            Notes = new List<NoteData>();

            Projects = new List<ProjectData>();

            ProjectUserMembers = new List<ProjectUserMemberData>();

            Sources = new List<SourceData>();

            SourceTypes = new List<SourceTypeData>();

            Sprints = new List<SprintData>();

            Statuses = new List<StatusData>();

            Stories = new List<StoryData>();

            Timelines = new List<TimelineData>();

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
        }
    }
}
