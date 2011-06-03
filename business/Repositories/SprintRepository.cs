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

            return sprint;
        }

        public static Sprint SprintUpdate(Sprint sprint)
        {
            sprint = sprint.Save();

            return sprint;
        }

        public static Sprint SprintNew(int projectId)
        {
            var sprint = Sprint.NewSprint(projectId);

            return sprint;
        }

        public static bool SprintDelete(Sprint sprint)
        {
            Sprint.DeleteSprint(
                new SprintDataCriteria
                {
                    SprintId = sprint.SprintId
                });

            return true;
        }

        public static bool SprintDelete(int sprintId)
        {
            return SprintRepository.SprintDelete(
                SprintRepository.SprintFetch(sprintId));
        }
    }
}
