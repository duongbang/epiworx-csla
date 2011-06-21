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
            return Sprint.FetchSprint(
                new SprintDataCriteria
                {
                    SprintId = sprintId
                });
        }

        public static SprintInfoList SprintFetchInfoList(int projectId)
        {
            ProjectUserRepository.AuthorizeProjectUser(projectId);

            return SprintInfoList.FetchSprintInfoList(
                new SprintDataCriteria
                    {
                        ProjectId = projectId
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

            return sprint;
        }

        public static Sprint SprintUpdate(Sprint sprint)
        {
            sprint = sprint.Save();

            SourceRepository.SourceUpdate(sprint.SprintId, SourceType.Sprint, sprint.Name);

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

            SourceRepository.SourceDelete(sprint.SprintId, SourceType.Sprint);

            return true;
        }

        public static bool SprintDelete(int sprintId)
        {
            return SprintRepository.SprintDelete(
                SprintRepository.SprintFetch(sprintId));
        }
    }
}
