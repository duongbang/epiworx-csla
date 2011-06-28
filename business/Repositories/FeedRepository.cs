using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class FeedRepository
    {
        public static Feed FeedFetch(int feedId)
        {
            return Feed.FetchFeed(
                new FeedDataCriteria
                {
                    FeedId = feedId
                });
        }

        public static FeedInfoList FeedFetchInfoList(int maximumRecords)
        {
            return FeedRepository.FeedFetchInfoList(
                new FeedDataCriteria
                    {
                        SortBy = "CreatedDate",
                        SortOrder = ListSortDirection.Descending,
                        MaximumRecords = maximumRecords
                    });
        }

        public static FeedInfoList FeedFetchInfoList(DateTime createdDateFrom, DateTime createdDateTo, int maximumRecords)
        {
            return FeedRepository.FeedFetchInfoList(
                new FeedDataCriteria
                {
                    CreatedDate = new DateRangeCriteria(createdDateFrom, createdDateTo),
                    SortBy = "CreatedDate",
                    SortOrder = ListSortDirection.Descending,
                    MaximumRecords = maximumRecords
                });
        }

        public static FeedInfoList FeedFetchInfoList(FeedDataCriteria criteria)
        {
            return FeedInfoList.FetchFeedInfoList(criteria);
        }

        internal static void FeedAdd(string action, Hour hour)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.Hour, hour.HourId);

            feed.Sources.Add(SourceType.Project, hour.ProjectId);
            feed.Sources.Add(SourceType.Story, hour.StoryId);
            feed.Sources.Add(SourceType.User, hour.UserId);

            feed.Save();
        }

        internal static void FeedAdd(string action, Note note)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.Note, note.NoteId);

            switch ((SourceType)note.SourceTypeId)
            {
                case SourceType.Project:
                    feed.Sources.Add(SourceType.Project, note.SourceId);
                    break;
                case SourceType.Sprint:
                    var sprint = SprintRepository.SprintFetch(note.SourceId);
                    feed.Sources.Add(SourceType.Project, sprint.ProjectId);
                    feed.Sources.Add(SourceType.Sprint, sprint.SprintId);
                    break;
                case SourceType.Story:
                    var story = StoryRepository.StoryFetch(note.SourceId);
                    feed.Sources.Add(SourceType.Project, story.ProjectId);
                    feed.Sources.Add(SourceType.Story, story.StoryId);
                    break;
            }

            feed.Save();
        }

        internal static void FeedAdd(string action, Project project)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.Project, project.ProjectId);

            if (action == FeedAction.Created)
            {
                feed.Description = project.Description;
            }

            feed.Save();
        }

        internal static void FeedAdd(string action, ProjectUser projectUser)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.ProjectUser, projectUser.ProjectUserMemberId);

            feed.Sources.Add(SourceType.Project, projectUser.ProjectId);

            feed.Save();
        }

        internal static void FeedAdd(string action, Sprint sprint)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.Sprint, sprint.SprintId);

            if (action == FeedAction.Created)
            {
                feed.Description = sprint.Description;
            }

            feed.Sources.Add(SourceType.Project, sprint.ProjectId);

            feed.Save();
        }

        internal static void FeedAdd(string action, Status status)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.Status, status.StatusId);

            feed.Sources.Add(SourceType.Project, status.ProjectId);

            feed.Save();
        }

        internal static void FeedAdd(string action, Story story)
        {
            var feed = FeedRepository.FeedNew(action, SourceType.Story, story.StoryId);

            if (action == FeedAction.Created)
            {
                feed.Description = story.Description;
            }

            feed.Sources.Add(SourceType.Project, story.ProjectId);

            feed.Save();
        }

        public static Feed FeedSave(Feed feed)
        {
            if (!feed.IsValid)
            {
                return feed;
            }

            Feed result;

            if (feed.IsNew)
            {
                result = FeedRepository.FeedInsert(feed);
            }
            else
            {
                result = FeedRepository.FeedUpdate(feed);
            }

            return result;
        }

        public static Feed FeedInsert(Feed feed)
        {
            feed = feed.Save();

            return feed;
        }

        public static Feed FeedUpdate(Feed feed)
        {
            feed = feed.Save();

            return feed;
        }

        public static Feed FeedNew()
        {
            var feed = Feed.NewFeed();

            return feed;
        }

        public static Feed FeedNew(string action, SourceType sourceType, int sourceId)
        {
            var feed = Feed.NewFeed();

            feed.Action = action;
            feed.SourceTypeId = (int)sourceType;
            feed.SourceId = sourceId;

            return feed;
        }
    }
}
