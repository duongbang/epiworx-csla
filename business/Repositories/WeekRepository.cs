using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class WeekRepository
    {
        public static void WeekAdd(DateTime startDate, DayOfWeek firstDayOfWeek, int numberOfPeriods, int year)
        {
            if (startDate.DayOfWeek != firstDayOfWeek)
            {
                throw new Csla.Rules.ValidationException("The start date's day of the week is not correct");
            }

            foreach (var week in WeekRepository.WeekFetchInfoList(year))
            {
                WeekRepository.WeekDelete(week.WeekId);
            }

            var numberOfWeeks = numberOfPeriods * 4;
            var endDate = startDate.AddDays(numberOfWeeks * 7);
            var weekCounter = 0;
            var periodCounter = 0;

            while (startDate < endDate)
            {
                var week = WeekRepository.WeekNew();

                week.StartDate = startDate;
                week.EndDate = week.StartDate.AddDays(6);
                week.Year = year;
                week.Period = periodCounter + 1;

                WeekRepository.WeekSave(week);

                startDate = startDate.AddDays(7);

                weekCounter++;

                if (weekCounter % 4 == 0)
                {
                    periodCounter++;
                }
            }
        }

        public static Week WeekFetch(int weekId)
        {
            return Week.FetchWeek(
                new WeekDataCriteria
                {
                    WeekId = weekId
                });
        }

        public static WeekInfoList WeekFetchInfoList()
        {
            return WeekInfoList.FetchWeekInfoList(
                new WeekDataCriteria());
        }

        public static WeekInfoList WeekFetchInfoList(int year)
        {
            return WeekInfoList.FetchWeekInfoList(
                new WeekDataCriteria
                    {
                        Year = year
                    });
        }

        public static WeekInfoList WeekFetchInfoList(WeekDataCriteria criteria)
        {
            return WeekInfoList.FetchWeekInfoList(criteria);
        }

        public static Week WeekSave(Week week)
        {
            if (!week.IsValid)
            {
                return week;
            }

            Week result;

            if (week.IsNew)
            {
                result = WeekRepository.WeekInsert(week);
            }
            else
            {
                result = WeekRepository.WeekUpdate(week);
            }

            return result;
        }

        public static Week WeekInsert(Week week)
        {
            week = week.Save();

            return week;
        }

        public static Week WeekUpdate(Week week)
        {
            if (!week.IsDirty)
            {
                return week;
            }

            week = week.Save();

            return week;
        }

        public static Week WeekNew()
        {
            var week = Week.NewWeek();

            return week;
        }

        public static bool WeekDelete(Week week)
        {
            Week.DeleteWeek(
                new WeekDataCriteria
                {
                    WeekId = week.WeekId
                });

            return true;
        }

        public static bool WeekDelete(int weekId)
        {
            return WeekRepository.WeekDelete(
                WeekRepository.WeekFetch(weekId));
        }
    }
}
