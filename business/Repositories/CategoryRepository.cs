using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class CategoryRepository
    {
        public static Category CategoryFetch(int categoryId)
        {
            return Category.FetchCategory(
                new CategoryDataCriteria
                {
                    CategoryId = categoryId
                });
        }

        public static CategoryInfoList CategoryFetchInfoList(CategoryDataCriteria criteria)
        {
            return CategoryInfoList.FetchCategoryInfoList(criteria);
        }

        public static Category CategorySave(Category category)
        {
            if (!category.IsValid)
            {
                return category;
            }

            Category result;

            if (category.IsNew)
            {
                result = CategoryRepository.CategoryInsert(category);
            }
            else
            {
                result = CategoryRepository.CategoryUpdate(category);
            }

            return result;
        }

        public static Category CategoryInsert(Category category)
        {
            category = category.Save();

            return category;
        }

        public static Category CategoryUpdate(Category category)
        {
            category = category.Save();

            return category;
        }

        public static Category CategoryNew()
        {
            var category = Category.NewCategory();

            return category;
        }

        public static bool CategoryDelete(Category category)
        {
            Category.DeleteCategory(
                new CategoryDataCriteria
                {
                    CategoryId = category.CategoryId
                });

            return true;
        }

        public static bool CategoryDelete(int categoryId)
        {
            return CategoryRepository.CategoryDelete(
                CategoryRepository.CategoryFetch(categoryId));
        }
    }
}
