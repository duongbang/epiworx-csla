using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business.Repositories
{
    using Epiworx.Data;

    public static class FindRepository
    {
        public static IEnumerable<FindResult> Find(string text)
        {
            var result = new List<FindResult>();

            // search hours
            var hours = HourRepository.HourFetchInfoList(new HourDataCriteria { Text = text });

            result.AddRange(hours.Select(hour => new FindResult
            {
                Id = hour.HourId,
                Type = "Hour",
                Name = hour.Date.ToShortDateString(),
                Description = hour.Notes,
                CreatedDate = hour.CreatedDate,
                CreatedByName = hour.CreatedByName,
                ModifiedDate = hour.ModifiedDate,
                ModifiedByName = hour.ModifiedByName
            }));

            // search projects
            var projects = ProjectRepository.ProjectFetchInfoList(new ProjectDataCriteria { Text = text });

            result.AddRange(projects.Select(project => new FindResult
                {
                    Id = project.ProjectId,
                    Type = "Project",
                    Name = project.Name,
                    Description = project.Description,
                    CreatedDate = project.CreatedDate,
                    CreatedByName = project.CreatedByName,
                    ModifiedDate = project.ModifiedDate,
                    ModifiedByName = project.ModifiedByName
                }));

            // search stories
            var stories = StoryRepository.StoryFetchInfoList(new StoryDataCriteria { Text = text });

            result.AddRange(stories.Select(story => new FindResult
                {
                    Id = story.StoryId,
                    Type = "Story",
                    Name = story.StoryId.ToString(),
                    Description = story.Description,
                    CreatedDate = story.CreatedDate,
                    CreatedByName = story.CreatedByName,
                    ModifiedDate = story.ModifiedDate,
                    ModifiedByName = story.ModifiedByName
                }));

            // search users
            var users = UserRepository.UserFetchInfoList(new UserDataCriteria { Text = text });

            result.AddRange(users.Select(user => new FindResult
                {
                    Id = user.UserId,
                    Type = "User",
                    Name = user.Name,
                    Description = string.Empty,
                    CreatedDate = user.CreatedDate,
                    CreatedByName = user.Name,
                    ModifiedDate = user.ModifiedDate,
                    ModifiedByName = user.Name
                }));

            return result;
        }
    }
}
