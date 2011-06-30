using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class StoryRepository
    {
        public static Story StoryFetch(int storyId)
        {
            return Story.FetchStory(
                new StoryDataCriteria
                {
                    StoryId = storyId
                });
        }

        public static StoryInfoList StoryFetchInfoList()
        {
            return StoryRepository.StoryFetchInfoList(new StoryDataCriteria());
        }

        public static StoryInfoList StoryFetchInfoList(IProject project)
        {
            ProjectUserRepository.AuthorizeProjectUser(project.ProjectId);

            return StoryInfoList.FetchStoryInfoList(
                new StoryDataCriteria
                {
                    ProjectId = new[] { project.ProjectId },
                    IsArchived = false
                });
        }

        public static StoryInfoList StoryFetchInfoList(ISprint sprint)
        {
            ProjectUserRepository.AuthorizeProjectUser(sprint.ProjectId);

            return StoryInfoList.FetchStoryInfoList(
                new StoryDataCriteria
                {
                    ProjectId = new[] { sprint.ProjectId },
                    SprintId = sprint.SprintId
                });
        }

        public static StoryInfoList StoryFetchInfoList(StoryDataCriteria criteria)
        {
            var projects = ProjectRepository.ProjectFetchInfoList()
                .Select(row => row.ProjectId);

            if (criteria.ProjectId == null)
            {
                criteria.ProjectId = projects.ToArray();
            }

            return StoryInfoList.FetchStoryInfoList(criteria);
        }

        public static Story StorySave(Story story)
        {
            if (!story.IsValid)
            {
                return story;
            }

            ProjectUserRepository.AuthorizeProjectUser(story.ProjectId);

            Story result;

            if (story.IsNew)
            {
                result = StoryRepository.StoryInsert(story);
            }
            else
            {
                result = StoryRepository.StoryUpdate(story);
            }

            return result;
        }

        public static Story StoryInsert(Story story)
        {
            story = story.Save();

            SourceRepository.SourceAdd(story.StoryId, SourceType.Story, story.StoryId.ToString());

            FeedRepository.FeedAdd(FeedAction.Created, story);

            return story;
        }

        public static Story StoryUpdate(Story story)
        {
            story = story.Save();

            SourceRepository.SourceUpdate(story.StoryId, SourceType.Story, story.StoryId.ToString());

            FeedRepository.FeedAdd(FeedAction.Edited, story);

            return story;
        }

        public static Story StoryNew()
        {
            var story = Story.NewStory();

            return story;
        }

        public static bool StoryDelete(Story story)
        {
            ProjectUserRepository.AuthorizeProjectUser(story.ProjectId);

            Story.DeleteStory(
                new StoryDataCriteria
                {
                    StoryId = story.StoryId
                });

            FeedRepository.FeedAdd(FeedAction.Deleted, story);

            return true;
        }

        public static bool StoryDelete(int storyId)
        {
            return StoryRepository.StoryDelete(
                StoryRepository.StoryFetch(storyId));
        }
    }
}
