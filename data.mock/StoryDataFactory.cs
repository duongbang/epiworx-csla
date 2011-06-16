using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class StoryDataFactory : IStoryDataFactory
    {
        public StoryData Fetch(StoryDataCriteria criteria)
        {
            var data = MockDb.Stories
                .Where(row => row.StoryId == criteria.StoryId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public StoryData Fetch(StoryData data)
        {
            data.AssignedToUser = MockDb.Users
                .Where(row => row.UserId == data.AssignedTo)
                .Single();

            data.Category = MockDb.Categories
                .Where(row => row.CategoryId == data.CategoryId)
                .Single();

            data.Project = MockDb.Projects
                .Where(row => row.ProjectId == data.ProjectId)
                .Single();

            data.Sprint = MockDb.Sprints
                .Where(row => row.SprintId == data.SprintId)
                .Single();

            data.Status = MockDb.Statuses
                .Where(row => row.StatusId == data.StatusId)
                .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public StoryData[] FetchInfoList(StoryDataCriteria criteria)
        {
            var query = MockDb.Stories
                .AsQueryable();

            var stories = query.AsQueryable();

            var data = new List<StoryData>();

            foreach (var story in stories)
            {
                data.Add(this.Fetch(story));
            }

            return data.ToArray();
        }

        public StoryData Create()
        {
            return new StoryData();
        }

        public StoryData Update(StoryData data)
        {
            var story = MockDb.Stories
                .Where(row => row.StoryId == data.StoryId)
                .Single();

            Csla.Data.DataMapper.Map(data, story);

            return data;
        }

        public StoryData Insert(StoryData data)
        {
            if (MockDb.Stories.Count() == 0)
            {
                data.StoryId = 1;
            }
            else
            {
                data.StoryId = MockDb.Stories.Select(row => row.StoryId).Max() + 1;
            }

            MockDb.Stories.Add(data);

            return data;
        }

        public void Delete(StoryDataCriteria criteria)
        {
            var data = MockDb.Stories
                .Where(row => row.StoryId == criteria.StoryId)
                .Single();

            MockDb.Stories.Remove(data);
        }
    }
}
