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

            status.Name = DataHelper.RandomString(20);

            return status;
        }
    }
}

