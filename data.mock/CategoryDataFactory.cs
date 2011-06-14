using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class CategoryDataFactory : ICategoryDataFactory
    {
        public CategoryData Fetch(CategoryDataCriteria criteria)
        {
            var data = MockDb.Categories
                .Where(row => row.CategoryId == criteria.CategoryId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public CategoryData Fetch(CategoryData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .SingleOrDefault();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .SingleOrDefault();

            return data;
        }

        public CategoryData[] FetchInfoList(CategoryDataCriteria criteria)
        {
            var query = MockDb.Categories
                .AsQueryable();

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            var categories = query.AsQueryable();

            var data = new List<CategoryData>();

            foreach (var category in categories)
            {
                data.Add(this.Fetch(category));
            }

            return data.ToArray();
        }

        public CategoryData Create()
        {
            return new CategoryData();
        }

        public CategoryData Update(CategoryData data)
        {
            var category = MockDb.Categories
                .Where(row => row.CategoryId == data.CategoryId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, category);

            return data;
        }

        public CategoryData Insert(CategoryData data)
        {
            if (MockDb.Categories.Count() == 0)
            {
                data.CategoryId = 1;
            }
            else
            {
                data.CategoryId = MockDb.Categories.Select(row => row.CategoryId).Max() + 1;
            }

            MockDb.Categories.Add(data);

            return data;
        }

        public void Delete(CategoryDataCriteria criteria)
        {
            var data = MockDb.Categories
                .Where(row => row.CategoryId == criteria.CategoryId)
                .SingleOrDefault();

            MockDb.Categories.Remove(data);
        }
    }
}
