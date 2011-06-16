using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class FilterTestHelper
    {
        public static Filter FilterAdd()
        {
            var filter = FilterTestHelper.FilterNew();

            filter = FilterRepository.FilterSave(filter);

            return  filter;
        }

        public static Filter FilterNew()
        {
            var  filter = FilterRepository.FilterNew();

            filter.Name = DataHelper.RandomString(50);

            return  filter;
        }
    }
}

