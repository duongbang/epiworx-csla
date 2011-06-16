using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class SourceTestHelper
    {
        public static Source SourceAdd(int sourceId, SourceType sourceType, string name)
        {
            var source = SourceTestHelper.SourceNew(sourceId, sourceType, name);

            source = SourceRepository.SourceSave(source);

            return source;
        }

        public static Source SourceNew(int sourceId, SourceType sourceType, string name)
        {
            var source = SourceRepository.SourceNew(sourceId, sourceType, name);

            return source;
        }
    }
}

