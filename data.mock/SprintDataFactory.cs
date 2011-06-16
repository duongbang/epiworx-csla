using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class SprintDataFactory : ISprintDataFactory
    {
        public SprintData Fetch(SprintDataCriteria criteria)
        {
            var data = MockDb.Sprints
                .Where(row => row.SprintId == criteria.SprintId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public SprintData Fetch(SprintData data)
        {
            data.Project = MockDb.Projects
               .Where(row => row.ProjectId == data.ProjectId)
               .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public SprintData[] FetchInfoList(SprintDataCriteria criteria)
        {
            var query = MockDb.Sprints
                .AsQueryable();

            var sprints = query.AsQueryable();

            var data = new List<SprintData>();

            foreach (var sprint in sprints)
            {
                data.Add(this.Fetch(sprint));
            }

            return data.ToArray();
        }

        public SprintData[] FetchLookupInfoList(SprintDataCriteria criteria)
        {
            var query = MockDb.Sprints
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public SprintData Create()
        {
            return new SprintData();
        }

        public SprintData Update(SprintData data)
        {
            var sprint = MockDb.Sprints
                .Where(row => row.SprintId == data.SprintId)
                .Single();

            Csla.Data.DataMapper.Map(data, sprint);

            return data;
        }

        public SprintData Insert(SprintData data)
        {
            if (MockDb.Sprints.Count() == 0)
            {
                data.SprintId = 1;
            }
            else
            {
                data.SprintId = MockDb.Sprints.Select(row => row.SprintId).Max() + 1;
            }

            MockDb.Sprints.Add(data);

            return data;
        }

        public void Delete(SprintDataCriteria criteria)
        {
            var data = MockDb.Sprints
                .Where(row => row.SprintId == criteria.SprintId)
                .Single();

            MockDb.Sprints.Remove(data);
        }
    }
}
