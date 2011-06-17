using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class SprintTestHelper
    {
        public static Sprint SprintAdd()
        {
            var sprint = SprintTestHelper.SprintNew();

            sprint = SprintRepository.SprintSave(sprint);

            return sprint;
        }

        public static Sprint SprintNew()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var sprint = SprintRepository.SprintNew(project.ProjectId);

            sprint.Name = DataHelper.RandomString(50);

            return sprint;
        }
    }
}