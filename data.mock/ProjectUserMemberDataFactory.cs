using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class ProjectUserMemberDataFactory : IProjectUserMemberDataFactory
    {
        public ProjectUserMemberData Fetch(ProjectUserMemberDataCriteria criteria)
        {
            var data = MockDb.ProjectUserMembers
                .Where(row => row.ProjectUserMemberId == criteria.ProjectUserMemberId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public ProjectUserMemberData Fetch(ProjectUserMemberData data)
        {
            data.Project = MockDb.Projects
               .Where(row => row.ProjectId == data.ProjectId)
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

        public ProjectUserMemberData[] FetchInfoList(ProjectUserMemberDataCriteria criteria)
        {
            var query = MockDb.ProjectUserMembers
                .AsQueryable();

            var projectUserMembers = query.AsQueryable();

            var data = new List<ProjectUserMemberData>();

            foreach (var projectUserMember in projectUserMembers)
            {
                data.Add(this.Fetch(projectUserMember));
            }

            return data.ToArray();
        }

        public ProjectUserMemberData[] FetchLookupInfoList(ProjectUserMemberDataCriteria criteria)
        {
            var query = MockDb.ProjectUserMembers
                .AsQueryable();

            var data = query.AsQueryable();

            return data.ToArray();
        }

        public ProjectUserMemberData Create()
        {
            return new ProjectUserMemberData();
        }

        public ProjectUserMemberData Update(ProjectUserMemberData data)
        {
            var projectUserMember = MockDb.ProjectUserMembers
                .Where(row => row.ProjectUserMemberId == data.ProjectUserMemberId)
                .Single();

            Csla.Data.DataMapper.Map(data, projectUserMember);

            return data;
        }

        public ProjectUserMemberData Insert(ProjectUserMemberData data)
        {
            if (MockDb.ProjectUserMembers.Count() == 0)
            {
                data.ProjectUserMemberId = 1;
            }
            else
            {
                data.ProjectUserMemberId = MockDb.ProjectUserMembers.Select(row => row.ProjectUserMemberId).Max() + 1;
            }

            MockDb.ProjectUserMembers.Add(data);

            return data;
        }

        public void Delete(ProjectUserMemberDataCriteria criteria)
        {
            var data = MockDb.ProjectUserMembers
                .Where(row => row.ProjectUserMemberId == criteria.ProjectUserMemberId)
                .Single();

            MockDb.ProjectUserMembers.Remove(data);
        }
    }
}
