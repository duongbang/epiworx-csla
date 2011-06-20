using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class StatusTestHelper
    {
        public static Status StatusAdd()
        {
            var status = StatusTestHelper.StatusNew();

            status = StatusRepository.StatusSave(status);

            return status;
        }

        public static Status StatusNew()
        {
            var status = StatusRepository.StatusNew();
            var project = ProjectTestHelper.ProjectAdd();

            status.Name = DataHelper.RandomString(20);
            status.ProjectId = project.ProjectId;

            return status;
        }
    }
}