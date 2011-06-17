using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class HourDataFactory : IHourDataFactory
    {
        public HourData Fetch(HourDataCriteria criteria)
        {
            var data = MockDb.Hours
                .Where(row => row.HourId == criteria.HourId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public HourData Fetch(HourData data)
        {
            data.Story = MockDb.Stories
               .Where(row => row.StoryId == data.StoryId)
               .Single();

            data.User = MockDb.Users
                .Where(row => row.UserId == data.UserId)
                .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public HourData[] FetchInfoList(HourDataCriteria criteria)
        {
            var query = MockDb.Hours
                .AsQueryable();

            var hours = query.AsQueryable();

            var data = new List<HourData>();

            foreach (var hour in hours)
            {
                data.Add(this.Fetch(hour));
            }

            return data.ToArray();
        }

        public HourData[] FetchLookupInfoList(HourDataCriteria criteria)
        {
            var query = MockDb.Hours
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public HourData Create()
        {
            return new HourData();
        }

        public HourData Update(HourData data)
        {
            var hour = MockDb.Hours
                .Where(row => row.HourId == data.HourId)
                .Single();

            Csla.Data.DataMapper.Map(data, hour);

            return data;
        }

        public HourData Insert(HourData data)
        {
            if (MockDb.Hours.Count() == 0)
            {
                data.HourId = 1;
            }
            else
            {
                data.HourId = MockDb.Hours.Select(row => row.HourId).Max() + 1;
            }

            MockDb.Hours.Add(data);

            return data;
        }

        public void Delete(HourDataCriteria criteria)
        {
            var data = MockDb.Hours
                .Where(row => row.HourId == criteria.HourId)
                .Single();

            MockDb.Hours.Remove(data);
        }
    }
}
