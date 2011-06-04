using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class SourceTypeTestHelper
    {
        public static SourceType SourceTypeAdd()
        {
            var sourceType = SourceTypeTestHelper.SourceTypeNew();

            sourceType = SourceTypeRepository.SourceTypeSave(sourceType);

            return  sourceType;
        }

        public static SourceType SourceTypeNew()
        {
            var  sourceType = SourceTypeRepository.SourceTypeNew();

            sourceType.Name = DataHelper.RandomString(50);

            return  sourceType;
        }
    }
}

