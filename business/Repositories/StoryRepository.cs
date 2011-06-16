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

        public static StoryInfoList StoryFetchInfoList(StoryDataCriteria criteria)
        {
            return StoryInfoList.FetchStoryInfoList(criteria);
        }

        public static Story StorySave(Story story)
        {
            if (!story.IsValid)
            {
                return story;
            }

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

            SourceRepository.SourceAdd(story.StoryId, SourceType.Story, story.Description);

            return story;
        }

        public static Story StoryUpdate(Story story)
        {
            story = story.Save();

            SourceRepository.SourceUpdate(story.StoryId, SourceType.Story, story.Description);

            return story;
        }

        public static Story StoryNew()
        {
            var story = Story.NewStory();

            return story;
        }

        public static bool StoryDelete(Story story)
        {
            Story.DeleteStory(
                new StoryDataCriteria
                {
                    StoryId = story.StoryId
                });

            SourceRepository.SourceDelete(story.StoryId, SourceType.Story);

            return true;
        }

        public static bool StoryDelete(int storyId)
        {
            return StoryRepository.StoryDelete(
                StoryRepository.StoryFetch(storyId));
        }
    }
}
