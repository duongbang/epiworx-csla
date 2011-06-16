using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class FilterDataFactory : IFilterDataFactory
    {
        public FilterData Fetch(FilterDataCriteria criteria)
        {
            var data = MockDb.Filters
                .Where(row => row.FilterId == criteria.FilterId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public FilterData Fetch(FilterData data)
        {
            data.SourceType = MockDb.SourceTypes
               .Where(row => row.SourceTypeId == data.SourceTypeId)
               .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public FilterData[] FetchInfoList(FilterDataCriteria criteria)
        {
            var query = MockDb.Filters
                .AsQueryable();

            var filters = query.AsQueryable();

            var data = new List<FilterData>();

            foreach (var filter in filters)
            {
                data.Add(this.Fetch(filter));
            }

            return data.ToArray();
        }

        public FilterData Create()
        {
            return new FilterData();
        }

        public FilterData Update(FilterData data)
        {
            var filter = MockDb.Filters
                .Where(row => row.FilterId == data.FilterId)
                .Single();

            Csla.Data.DataMapper.Map(data, filter);

            return data;
        }

        public FilterData Insert(FilterData data)
        {
            if (MockDb.Filters.Count() == 0)
            {
                data.FilterId = 1;
            }
            else
            {
                data.FilterId = MockDb.Filters.Select(row => row.FilterId).Max() + 1;
            }

            MockDb.Filters.Add(data);

            return data;
        }

        public void Delete(FilterDataCriteria criteria)
        {
            var data = MockDb.Filters
                .Where(row => row.FilterId == criteria.FilterId)
                .Single();

            MockDb.Filters.Remove(data);
        }
    }
}
