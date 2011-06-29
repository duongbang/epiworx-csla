using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class WeekTestHelper
    {
        public static Week WeekAdd()
        {
            var week = WeekTestHelper.WeekNew();

            week = WeekRepository.WeekSave(week);

            return week;
        }

        public static Week WeekNew()
        {
            var week = WeekRepository.WeekNew();

            week.StartDate = DateTime.Now.AddDays(DataHelper.RandomNumber(1000));
            week.EndDate = week.StartDate.AddDays(7);
            week.Year = week.StartDate.Year;
            week.Period = 1;

            return week;
        }
    }
}

