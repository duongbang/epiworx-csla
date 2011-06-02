using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class ProjectTestHelper
    {
        public static Project ProjectAdd()
        {
            var project = ProjectTestHelper.ProjectNew();

            project = ProjectRepository.ProjectSave(project);

            return project;
        }

        public static Project ProjectNew()
        {
            var project = ProjectRepository.ProjectNew();

            project.Name = DataHelper.RandomString(50);

            return project;
        }
    }
}

