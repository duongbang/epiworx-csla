using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class SourceTypeDataFactory : ISourceTypeDataFactory
    {
        public SourceTypeData Fetch(SourceTypeDataCriteria criteria)
        {
            var data = MockDb.SourceTypes
                .Where(row => row.SourceTypeId == criteria.SourceTypeId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public SourceTypeData Fetch(SourceTypeData data)
        {
            return data;
        }

        public SourceTypeData[] FetchInfoList(SourceTypeDataCriteria criteria)
        {
            var query = MockDb.SourceTypes
                .AsQueryable();

            var sourceTypes = query.AsQueryable();

            var data = new List<SourceTypeData>();

            foreach (var sourceType in sourceTypes)
            {
                data.Add(this.Fetch(sourceType));
            }

            return data.ToArray();
        }

        public SourceTypeData Create()
        {
            return new SourceTypeData();
        }

        public SourceTypeData Update(SourceTypeData data)
        {
            var sourceType = MockDb.SourceTypes
                .Where(row => row.SourceTypeId == data.SourceTypeId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, sourceType);

            return data;
        }

        public SourceTypeData Insert(SourceTypeData data)
        {
            if (MockDb.SourceTypes.Count() == 0)
            {
                data.SourceTypeId = 1;
            }
            else
            {
                data.SourceTypeId = MockDb.SourceTypes.Select(row => row.SourceTypeId).Max() + 1;
            }

            MockDb.SourceTypes.Add(data);

            return data;
        }

        public void Delete(SourceTypeDataCriteria criteria)
        {
            var data = MockDb.SourceTypes
                .Where(row => row.SourceTypeId == criteria.SourceTypeId)
                .SingleOrDefault();

            MockDb.SourceTypes.Remove(data);
        }
    }
}
