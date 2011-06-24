using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class StoryDataFactory : IStoryDataFactory
    {
        public StoryData Fetch(StoryDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var story = this.Fetch(ctx, criteria)
                    .Single();

                var storyData = new StoryData();

                this.Fetch(story, storyData);

                return storyData;
            }
        }

        public StoryData[] FetchInfoList(StoryDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var stories = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var storyDataList = new List<StoryData>();

                foreach (var story in stories)
                {
                    var storyData = new StoryData();

                    this.Fetch(story, storyData);

                    storyDataList.Add(storyData);
                }

                return storyDataList.ToArray();
            }
        }

        public StoryData[] FetchLookupInfoList(StoryDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var stories = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var storyDataList = new List<StoryData>();

                foreach (var story in stories)
                {
                    var storyData = new StoryData();

                    this.Fetch(story, storyData);

                    storyDataList.Add(storyData);
                }

                return storyDataList.ToArray();
            }
        }

        public StoryData Create()
        {
            return new StoryData();
        }

        public StoryData Update(StoryData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var story =
                    new Story
                    {
                        StoryId = data.StoryId
                    };

                ctx.ObjectContext.Stories.Attach(story);

                DataMapper.Map(data, story);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public StoryData Insert(StoryData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var story = new Story();

                DataMapper.Map(data, story);

                ctx.ObjectContext.AddToStories(story);

                ctx.ObjectContext.SaveChanges();

                data.StoryId = story.StoryId;

                return data;
            }
        }

        public void Delete(StoryDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var story = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Stories.DeleteObject(story);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Story story, StoryData storyData)
        {
            DataMapper.Map(story, storyData);

            storyData.AssignedToUser = new UserData();
            if (story.AssignedTo != 0)
            {
                DataMapper.Map(story.AssignedToUser, storyData.AssignedToUser);
            }

            storyData.Project = new ProjectData();
            DataMapper.Map(story.Project, storyData.Project);

            storyData.Sprint = new SprintData();
            if (story.SprintId != 0)
            {
                DataMapper.Map(story.Sprint, storyData.Sprint);
            }

            storyData.Status = new StatusData();
            DataMapper.Map(story.Status, storyData.Status);

            storyData.CreatedByUser = new UserData();
            DataMapper.Map(story.CreatedByUser, storyData.CreatedByUser);

            storyData.ModifiedByUser = new UserData();
            DataMapper.Map(story.ModifiedByUser, storyData.ModifiedByUser);
        }

        private IQueryable<Story> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             StoryDataCriteria criteria)
        {
            IQueryable<Story> query = ctx.ObjectContext.Stories
                .Include("Project")
                .Include("Sprint")
                .Include("Status")
                .Include("AssignedToUser")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.StoryId != null)
            {
                query = query.Where(row => row.StoryId == criteria.StoryId);
            }

            if (criteria.AssignedTo != null)
            {
                query = query.Where(row => row.AssignedTo == criteria.AssignedTo);
            }

            if (criteria.AssignedToName != null)
            {
                query = query.Where(row => row.AssignedToUser.Name == criteria.AssignedToName);
            }

            if (criteria.AssignedDate != null
                && criteria.AssignedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.AssignedDate >= criteria.AssignedDate.DateFrom);
            }

            if (criteria.AssignedDate != null
                && (criteria.AssignedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.AssignedDate <= criteria.AssignedDate.DateTo);
            }

            if (criteria.CompletedDate != null
                && criteria.CompletedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CompletedDate >= criteria.CompletedDate.DateFrom);
            }

            if (criteria.CompletedDate != null
                && (criteria.CompletedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.CompletedDate <= criteria.CompletedDate.DateTo);
            }

            if (criteria.Description != null)
            {
                query = query.Where(row => row.Description.Contains(criteria.Description));
            }

            if (criteria.Duration != null)
            {
                query = query.Where(row => row.Duration == criteria.Duration);
            }

            if (criteria.EstimatedCompletedDate != null
                && criteria.EstimatedCompletedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.EstimatedCompletedDate >= criteria.EstimatedCompletedDate.DateFrom);
            }

            if (criteria.EstimatedCompletedDate != null
                && (criteria.EstimatedCompletedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.EstimatedCompletedDate <= criteria.EstimatedCompletedDate.DateTo);
            }

            if (criteria.EstimatedDuration != null)
            {
                query = query.Where(row => row.EstimatedDuration == criteria.EstimatedDuration);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.IsCompleted != null)
            {
                query = query.Where(row => row.IsCompleted == criteria.IsCompleted);
            }

            if (criteria.ProjectId != null)
            {
                query = query.Where(row => criteria.ProjectId.Contains(row.ProjectId));
            }

            if (criteria.ProjectName != null)
            {
                query = query.Where(row => row.Project.Name == criteria.ProjectName);
            }

            if (criteria.SprintId != null)
            {
                query = query.Where(row => row.SprintId == criteria.SprintId);
            }

            if (criteria.StartDate != null
                && criteria.StartDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.StartDate >= criteria.StartDate.DateFrom);
            }

            if (criteria.StartDate != null
                && (criteria.StartDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.StartDate <= criteria.StartDate.DateTo);
            }

            if (criteria.StatusId != null)
            {
                query = query.Where(row => row.StatusId == criteria.StatusId);
            }

            if (criteria.StatusName != null)
            {
                query = query.Where(row => row.Status.Name == criteria.StatusName);
            }

            if (criteria.ModifiedBy != null)
            {
                query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null
                && (criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null
                && (criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.Text != null)
            {
                query = query.Where(row => row.Description.Contains(criteria.Text));
            }

            if (criteria.SortBy != null)
            {
                query = query.OrderBy(string.Format(
                    "{0} {1}",
                    criteria.SortBy,
                    criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            if (criteria.SkipRecords != null)
            {
                query = query.Skip(criteria.SkipRecords.Value);
            }

            if (criteria.MaximumRecords != null)
            {
                query = query.Take(criteria.MaximumRecords.Value);
            }

            return query;
        }
    }
}
