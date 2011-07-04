using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class TimelineDataFactory : ITimelineDataFactory
    {
        public TimelineData Fetch(TimelineDataCriteria criteria)
        {
            var data = MockDb.Timelines
                .Where(row => row.TimelineId == criteria.TimelineId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public TimelineData Fetch(TimelineData data)
        {
            data.Source = MockDb.Sources
               .Where(row => row.SourceId == data.SourceId
                    && row.SourceTypeId == data.SourceTypeId)
               .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public TimelineData[] FetchInfoList(TimelineDataCriteria criteria)
        {
            var query = MockDb.Timelines
                .AsQueryable();

            var notes = query.AsQueryable();

            var data = new List<TimelineData>();

            foreach (var note in notes)
            {
                data.Add(this.Fetch(note));
            }

            return data.ToArray();
        }

        public TimelineData Create()
        {
            return new TimelineData();
        }

        public TimelineData Update(TimelineData data)
        {
            var note = MockDb.Timelines
                .Where(row => row.TimelineId == data.TimelineId)
                .Single();

            Csla.Data.DataMapper.Map(data, note);

            return data;
        }

        public TimelineData Insert(TimelineData data)
        {
            if (MockDb.Timelines.Count() == 0)
            {
                data.TimelineId = 1;
            }
            else
            {
                data.TimelineId = MockDb.Timelines.Select(row => row.TimelineId).Max() + 1;
            }

            MockDb.Timelines.Add(data);

            return data;
        }

        public void Delete(TimelineDataCriteria criteria)
        {
            var data = MockDb.Timelines
                .Where(row => row.TimelineId == criteria.TimelineId)
                .Single();

            MockDb.Timelines.Remove(data);
        }
    }
}
