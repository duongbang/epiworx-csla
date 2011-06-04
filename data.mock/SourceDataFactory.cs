using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class SourceDataFactory : ISourceDataFactory
    {
        public SourceData Fetch(SourceDataCriteria criteria)
        {
            var data = MockDb.Sources
                .Where(row => row.SourceId == criteria.SourceId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public SourceData Fetch(SourceData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public SourceData[] FetchInfoList(SourceDataCriteria criteria)
        {
            var query = MockDb.Sources
                .AsQueryable();

            var sources = query.AsQueryable();

            var data = new List<SourceData>();

            foreach (var source in sources)
            {
                data.Add(this.Fetch(source));
            }

            return data.ToArray();
        }

        public SourceData Create()
        {
            return new SourceData();
        }

        public SourceData Update(SourceData data)
        {
            var source = MockDb.Sources
                .Where(row => row.SourceId == data.SourceId)
                .Single();

            Csla.Data.DataMapper.Map(data, source);

            return data;
        }

        public SourceData Insert(SourceData data)
        {
            if (MockDb.Sources.Count() == 0)
            {
                data.SourceId = 1;
            }
            else
            {
                data.SourceId = MockDb.Sources.Select(row => row.SourceId).Max() + 1;
            }

            MockDb.Sources.Add(data);

            return data;
        }

        public void Delete(SourceDataCriteria criteria)
        {
            var data = MockDb.Sources
                .Where(row => row.SourceId == criteria.SourceId)
                .Single();

            MockDb.Sources.Remove(data);
        }
    }
}
