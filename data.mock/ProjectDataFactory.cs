using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class ProjectDataFactory : IProjectDataFactory
    {
        public ProjectData Fetch(ProjectDataCriteria criteria)
        {
            var data = MockDb.Projects
                .Where(row => row.ProjectId == criteria.ProjectId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public ProjectData Fetch(ProjectData data)
        {
            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .SingleOrDefault();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .SingleOrDefault();

            return data;
        }

        public ProjectData[] FetchInfoList(ProjectDataCriteria criteria)
        {
            var query = MockDb.Projects
                .AsQueryable();

            var projects = query.AsQueryable();

            var data = new List<ProjectData>();

            foreach (var project in projects)
            {
                data.Add(this.Fetch(project));
            }

            return data.ToArray();
        }

        public ProjectData[] FetchLookupInfoList(ProjectDataCriteria criteria)
        {
            var query = MockDb.Projects
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public ProjectData Create()
        {
            return new ProjectData();
        }

        public ProjectData Update(ProjectData data)
        {
            var project = MockDb.Projects
                .Where(row => row.ProjectId == data.ProjectId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, project);

            return data;
        }

        public ProjectData Insert(ProjectData data)
        {
            if (MockDb.Projects.Count() == 0)
            {
                data.ProjectId = 1;
            }
            else
            {
                data.ProjectId = MockDb.Projects.Select(row => row.ProjectId).Max() + 1;
            }

            MockDb.Projects.Add(data);

            return data;
        }

        public void Delete(ProjectDataCriteria criteria)
        {
            var data = MockDb.Projects
                .Where(row => row.ProjectId == criteria.ProjectId)
                .SingleOrDefault();

            MockDb.Projects.Remove(data);
        }
    }
}
