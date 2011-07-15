using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class WeekCollection : List<Week>
    {
        public DateTime StartDate
        {
            get { return this.Min(row => row.StartDate); }
        }

        public DateTime EndDate
        {
            get { return this.Max(row => row.EndDate); }
        }

        public static WeekCollection GetWeeks(int year)
        {
            var result = new WeekCollection();

            DateTime startDate;
            DateTime endDate;

            startDate = DateTime.Parse(string.Format("1/1/{0}", year));

            while (startDate.DayOfWeek != Settings.StartDayOfWeek)
            {
                startDate = startDate.AddDays(-1);
            }

            endDate = startDate.AddYears(1);

            while (endDate.DayOfWeek != Settings.EndDayOfWeek)
            {
                endDate = endDate.AddDays(-1);
            }

            var currentDate = startDate;

            while (currentDate <= endDate)
            {
                result.Add(
                    new Week
                    {
                        StartDate = currentDate,
                        EndDate = currentDate.AddDays(6)
                    });
                currentDate = currentDate.AddDays(7);
            }

            return result;
        }
    }
}