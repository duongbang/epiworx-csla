using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class HourTestHelper
    {
        public static Hour HourAdd()
        {
            var hour = HourTestHelper.HourNew();

            hour = HourRepository.HourSave(hour);

            return hour;
        }

        public static Hour HourNew()
        {
            var story = StoryTestHelper.StoryAdd();
            var user = UserTestHelper.UserAdd();

            var hour = HourRepository.HourNew();

            hour.StoryId = story.StoryId;
            hour.UserId = user.UserId;
            hour.Notes = DataHelper.RandomString(50);

            return hour;
        }
    }
}