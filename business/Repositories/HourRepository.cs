using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class HourRepository
    {
        public static Hour HourFetch(int hourId)
        {
            return Hour.FetchHour(
                new HourDataCriteria
                {
                    HourId = hourId
                });
        }

        public static HourInfoList HourFetchInfoList()
        {
            return HourRepository.HourFetchInfoList(
                new HourDataCriteria());
        }

        public static HourInfoList HourFetchInfoList(IStory story)
        {
            return HourInfoList.FetchHourInfoList(
                new HourDataCriteria
                    {
                        StoryId = story.StoryId
                    });
        }

        public static HourInfoList HourFetchInfoList(IProject project)
        {
            return HourInfoList.FetchHourInfoList(
                new HourDataCriteria
                {
                    ProjectId = new[] { project.ProjectId }
                });
        }

        public static HourInfoList HourFetchInfoList(ISprint sprint)
        {
            return HourInfoList.FetchHourInfoList(
                new HourDataCriteria
                {
                    ProjectId = new[] { sprint.ProjectId },
                    SprintId = sprint.SprintId
                });
        }

        public static HourInfoList HourFetchInfoList(HourDataCriteria criteria)
        {
            criteria.ProjectId = ProjectRepository.ProjectFetchInfoList()
                .Select(row => row.ProjectId)
                .ToArray();

            return HourInfoList.FetchHourInfoList(criteria);
        }

        public static Hour HourSave(Hour hour)
        {
            if (!hour.IsValid)
            {
                return hour;
            }

            Hour result;

            if (hour.IsNew)
            {
                result = HourRepository.HourInsert(hour);
            }
            else
            {
                result = HourRepository.HourUpdate(hour);
            }

            return result;
        }

        public static Hour HourInsert(Hour hour)
        {
            hour = hour.Save();

            return hour;
        }

        public static Hour HourUpdate(Hour hour)
        {
            hour = hour.Save();

            return hour;
        }

        public static Hour HourNew()
        {
            var hour = Hour.NewHour();

            return hour;
        }

        public static bool HourDelete(Hour hour)
        {
            Hour.DeleteHour(
                new HourDataCriteria
                {
                    HourId = hour.HourId
                });

            return true;
        }

        public static bool HourDelete(int hourId)
        {
            return HourRepository.HourDelete(
                HourRepository.HourFetch(hourId));
        }
    }
}
