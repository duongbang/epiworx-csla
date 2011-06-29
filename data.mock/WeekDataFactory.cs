using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class WeekDataFactory : IWeekDataFactory
    {
        public WeekData Fetch(WeekDataCriteria criteria)
        {
            var data = MockDb.Weeks
                .Where(row => row.WeekId == criteria.WeekId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public WeekData Fetch(WeekData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public WeekData[] FetchInfoList(WeekDataCriteria criteria)
        {
            var query = MockDb.Weeks
                .AsQueryable();

            var weeks = query.AsQueryable();

            var data = new List<WeekData>();

            foreach (var week in weeks)
            {
                data.Add(this.Fetch(week));
            }

            return data.ToArray();
        }

        public WeekData Create()
        {
            return new WeekData();
        }

        public WeekData Update(WeekData data)
        {
            var week = MockDb.Weeks
                .Where(row => row.WeekId == data.WeekId)
                .Single();

            Csla.Data.DataMapper.Map(data, week);

            return data;
        }

        public WeekData Insert(WeekData data)
        {
            if (MockDb.Weeks.Count() == 0)
            {
                data.WeekId = 1;
            }
            else
            {
                data.WeekId = MockDb.Weeks.Select(row => row.WeekId).Max() + 1;
            }

            MockDb.Weeks.Add(data);

            return data;
        }

        public void Delete(WeekDataCriteria criteria)
        {
            var data = MockDb.Weeks
                .Where(row => row.WeekId == criteria.WeekId)
                .Single();

            MockDb.Weeks.Remove(data);
        }
    }
}
