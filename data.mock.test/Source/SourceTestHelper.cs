using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class SourceTestHelper
    {
        public static Source SourceAdd()
        {
            var source = SourceTestHelper.SourceNew();

            source = SourceRepository.SourceSave(source);

            return  source;
        }

        public static Source SourceNew()
        {
            var  source = SourceRepository.SourceNew();

            source.Name = DataHelper.RandomString(50);

            return  source;
        }
    }
}

