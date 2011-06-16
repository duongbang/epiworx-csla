using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class StoryTestHelper
    {
        public static Story StoryAdd()
        {
            var story = StoryTestHelper.StoryNew();

            story = StoryRepository.StorySave(story);

            return  story;
        }

        public static Story StoryNew()
        {
            var  story = StoryRepository.StoryNew();

            story.Description = DataHelper.RandomString(50);

            return  story;
        }
    }
}

