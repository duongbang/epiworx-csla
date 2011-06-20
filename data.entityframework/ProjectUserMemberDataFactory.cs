using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class ProjectUserMemberDataFactory : IProjectUserMemberDataFactory
    {
        public ProjectUserMemberData Fetch(ProjectUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var projectUserMember = this.Fetch(ctx, criteria)
                    .Single();

                var projectUserMemberData = new ProjectUserMemberData();

                this.Fetch(projectUserMember, projectUserMemberData);

                return projectUserMemberData;
            }
        }

        public ProjectUserMemberData[] FetchInfoList(ProjectUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var projectUserMembers = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var projectUserMemberDataList = new List<ProjectUserMemberData>();

                foreach (var projectUserMember in projectUserMembers)
                {
                    var projectUserMemberData = new ProjectUserMemberData();

                    this.Fetch(projectUserMember, projectUserMemberData);

                    projectUserMemberDataList.Add(projectUserMemberData);
                }

                return projectUserMemberDataList.ToArray();
            }
        }

        public ProjectUserMemberData[] FetchLookupInfoList(ProjectUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var projectUserMembers = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var projectUserMemberDataList = new List<ProjectUserMemberData>();

                foreach (var projectUserMember in projectUserMembers)
                {
                    var projectUserMemberData = new ProjectUserMemberData();

                    this.Fetch(projectUserMember, projectUserMemberData);

                    projectUserMemberDataList.Add(projectUserMemberData);
                }

                return projectUserMemberDataList.ToArray();
            }
        }

        public ProjectUserMemberData Create()
        {
            return new ProjectUserMemberData();
        }

        public ProjectUserMemberData Update(ProjectUserMemberData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var projectUserMember =
                    new ProjectUserMember
                    {
                        ProjectUserMemberId = data.ProjectUserMemberId
                    };

                ctx.ObjectContext.ProjectUserMembers.Attach(projectUserMember);

                DataMapper.Map(data, projectUserMember);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public ProjectUserMemberData Insert(ProjectUserMemberData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var projectUserMember = new ProjectUserMember();

                DataMapper.Map(data, projectUserMember);

                ctx.ObjectContext.AddToProjectUserMembers(projectUserMember);

                ctx.ObjectContext.SaveChanges();

                data.ProjectUserMemberId = projectUserMember.ProjectUserMemberId;

                return data;
            }
        }

        public void Delete(ProjectUserMemberDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var projectUserMember = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.ProjectUserMembers.DeleteObject(projectUserMember);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(ProjectUserMember projectUserMember, ProjectUserMemberData projectUserMemberData)
        {
            DataMapper.Map(projectUserMember, projectUserMemberData);

            projectUserMemberData.Project = new ProjectData();
            DataMapper.Map(projectUserMember.Project, projectUserMemberData.Project);

            projectUserMemberData.User = new UserData();
            DataMapper.Map(projectUserMember.User, projectUserMemberData.User);

            projectUserMemberData.CreatedByUser = new UserData();
            DataMapper.Map(projectUserMember.CreatedByUser, projectUserMemberData.CreatedByUser);

            projectUserMemberData.ModifiedByUser = new UserData();
            DataMapper.Map(projectUserMember.ModifiedByUser, projectUserMemberData.ModifiedByUser);
        }

        private IQueryable<ProjectUserMember> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             ProjectUserMemberDataCriteria criteria)
        {
            IQueryable<ProjectUserMember> query = ctx.ObjectContext.ProjectUserMembers
                .Include("Project")
                .Include("User")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.ProjectUserMemberId != null)
            {
                query = query.Where(row => row.ProjectUserMemberId == criteria.ProjectUserMemberId);
            }

            if (criteria.ProjectId != null)
            {
                query = query.Where(row => row.ProjectId == criteria.ProjectId);
            }

            if (criteria.RoleId != null)
            {
                query = query.Where(row => row.RoleId == criteria.RoleId);
            }

            if (criteria.UserId != null)
            {
                query = query.Where(row => row.UserId == criteria.UserId);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.ModifiedBy != null)
            {
                query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
            }

            if (criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.SortBy != null)
            {
                query = query.OrderBy(string.Format(
                    "{0} {1}",
                    criteria.SortBy,
                    criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            if (criteria.SkipRecords != null)
            {
                query = query.Skip(criteria.SkipRecords.Value);
            }

            if (criteria.MaximumRecords != null)
            {
                query = query.Take(criteria.MaximumRecords.Value);
            }

            return query;
        }
    }
}
