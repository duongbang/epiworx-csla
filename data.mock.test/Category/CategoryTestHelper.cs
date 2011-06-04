using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class CategoryTestHelper
    {
        public static Category CategoryAdd()
        {
            var category = CategoryTestHelper.CategoryNew();

            category = CategoryRepository.CategorySave(category);

            return category;
        }

        public static Category CategoryNew()
        {
            var category = CategoryRepository.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            return category;
        }
    }
}

