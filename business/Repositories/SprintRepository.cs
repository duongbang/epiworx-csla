using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class SprintRepository
    {
        public static Sprint SprintFetch(int sprintId)
        {
            var result = Sprint.FetchSprint(
                new SprintDataCriteria
                {
                    SprintId = sprintId
                });

            result.Auditor = new SprintAuditor(result.Clone());

            return result;
        }

        public static SprintInfoList SprintFetchInfoList(IProject project)
        {
            ProjectUserRepository.AuthorizeProjectUser(project.ProjectId);

            return SprintInfoList.FetchSprintInfoList(
                new SprintDataCriteria
                    {
                        ProjectId = new[] { project.ProjectId }
                    });
        }

        public static SprintInfoList SprintFetchInfoList(IProject[] projects, bool? isArchived)
        {
            var projectIds = projects.Select(row => row.ProjectId).ToArray();

            ProjectUserRepository.AuthorizeProjectUser(projectIds);

            return SprintInfoList.FetchSprintInfoList(
                new SprintDataCriteria
                {
                    ProjectId = projectIds,
                    IsArchived = isArchived
                });
        }

        public static SprintInfoList SprintFetchInfoList(SprintDataCriteria criteria)
        {
            return SprintInfoList.FetchSprintInfoList(criteria);
        }

        public static Sprint SprintSave(Sprint sprint)
        {
            if (!sprint.IsValid)
            {
                return sprint;
            }

            ProjectUserRepository.AuthorizeProjectUser(sprint.ProjectId);

            Sprint result;

            if (sprint.IsNew)
            {
                result = SprintRepository.SprintInsert(sprint);
            }
            else
            {
                result = SprintRepository.SprintUpdate(sprint);
            }

            return result;
        }

        public static Sprint SprintInsert(Sprint sprint)
        {
            sprint = sprint.Save();

            SourceRepository.SourceAdd(sprint.SprintId, SourceType.Sprint, sprint.Name);

            FeedRepository.FeedAdd(FeedAction.Created, sprint);

            return sprint;
        }

        public static Sprint SprintUpdate(Sprint sprint)
        {
            if (!sprint.IsDirty)
            {
                return sprint;
            }

            sprint = sprint.Save();

            SourceRepository.SourceUpdate(sprint.SprintId, SourceType.Sprint, sprint.Name);

            FeedRepository.FeedAdd(FeedAction.Edited, sprint);

            return sprint;
        }

        public static Sprint SprintNew(int projectId)
        {
            var sprint = Sprint.NewSprint(projectId);

            return sprint;
        }

        public static bool SprintDelete(Sprint sprint)
        {
            ProjectUserRepository.AuthorizeProjectUser(sprint.ProjectId);

            Sprint.DeleteSprint(
                new SprintDataCriteria
                {
                    SprintId = sprint.SprintId
                });

            FeedRepository.FeedAdd(FeedAction.Deleted, sprint);

            return true;
        }

        public static bool SprintDelete(int sprintId)
        {
            return SprintRepository.SprintDelete(
                SprintRepository.SprintFetch(sprintId));
        }
    }
}
