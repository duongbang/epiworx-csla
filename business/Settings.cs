using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public class Settings
    {
        public const int SaltSize = 10;
        public const int TokenExpirationNumberOfHours = 24;

        public static int StartYear
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["StartYear"]);
                }
                catch
                {
                    return DateTime.Now.Year;
                }
            }
        }

        public static DayOfWeek StartDayOfWeek
        {
            get
            {
                try
                {
                    return (DayOfWeek)int.Parse(ConfigurationManager.AppSettings["StartDayOfWeek"]);
                }
                catch
                {
                    return DayOfWeek.Monday;
                }
            }
        }

        public static DayOfWeek EndDayOfWeek
        {
            get
            {
                switch (Settings.StartDayOfWeek)
                {
                    case DayOfWeek.Friday:
                        return DayOfWeek.Thursday;
                    case DayOfWeek.Monday:
                        return DayOfWeek.Sunday;
                    case DayOfWeek.Saturday:
                        return DayOfWeek.Friday;
                    case DayOfWeek.Sunday:
                        return DayOfWeek.Saturday;
                    case DayOfWeek.Thursday:
                        return DayOfWeek.Wednesday;
                    case DayOfWeek.Tuesday:
                        return DayOfWeek.Monday;
                    case DayOfWeek.Wednesday:
                        return DayOfWeek.Tuesday;
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}
