using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class StatusDataFactory : IStatusDataFactory
    {
        public StatusData Fetch(StatusDataCriteria criteria)
        {
            var data = MockDb.Statuses
                .Where(row => row.StatusId == criteria.StatusId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public StatusData Fetch(StatusData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .SingleOrDefault();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .SingleOrDefault();

            return data;
        }

        public StatusData[] FetchInfoList(StatusDataCriteria criteria)
        {
            var query = MockDb.Statuses
                .AsQueryable();

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            var statuses = query.AsQueryable();

            var data = new List<StatusData>();

            foreach (var status in statuses)
            {
                data.Add(this.Fetch(status));
            }

            return data.ToArray();
        }

        public StatusData Create()
        {
            return new StatusData();
        }

        public StatusData Update(StatusData data)
        {
            var status = MockDb.Statuses
                .Where(row => row.StatusId == data.StatusId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, status);

            return data;
        }

        public StatusData Insert(StatusData data)
        {
            if (MockDb.Statuses.Count() == 0)
            {
                data.StatusId = 1;
            }
            else
            {
                data.StatusId = MockDb.Statuses.Select(row => row.StatusId).Max() + 1;
            }

            MockDb.Statuses.Add(data);

            return data;
        }

        public void Delete(StatusDataCriteria criteria)
        {
            var data = MockDb.Statuses
                .Where(row => row.StatusId == criteria.StatusId)
                .SingleOrDefault();

            MockDb.Statuses.Remove(data);
        }
    }
}
