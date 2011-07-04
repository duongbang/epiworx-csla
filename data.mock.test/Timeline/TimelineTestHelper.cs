using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class TimelineTestHelper
    {
        public static Timeline TimelineAdd()
        {
            var timeline = TimelineTestHelper.TimelineNew();

            timeline = TimelineRepository.TimelineSave(timeline);

            return timeline;
        }

        public static Timeline TimelineNew()
        {
            var project = ProjectTestHelper.ProjectAdd();
            var timeline = TimelineRepository.TimelineNew();

            timeline.Body = DataHelper.RandomString(1000);
            timeline.SourceId = project.ProjectId;
            timeline.SourceTypeId = (int)SourceType.Project;

            return timeline;
        }
    }
}