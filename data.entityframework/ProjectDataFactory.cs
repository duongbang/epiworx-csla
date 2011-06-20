using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class ProjectDataFactory : IProjectDataFactory
    {
        public ProjectData Fetch(ProjectDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var project = this.Fetch(ctx, criteria)
                    .Single();

                var projectData = new ProjectData();

                this.Fetch(project, projectData);

                return projectData;
            }
        }

        public ProjectData[] FetchInfoList(ProjectDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var projects = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var projectDataList = new List<ProjectData>();

                foreach (var project in projects)
                {
                    var projectData = new ProjectData();

                    this.Fetch(project, projectData);

                    projectDataList.Add(projectData);
                }

                return projectDataList.ToArray();
            }
        }

        public ProjectData[] FetchLookupInfoList(ProjectDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var projects = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var projectDataList = new List<ProjectData>();

                foreach (var project in projects)
                {
                    var projectData = new ProjectData();

                    this.Fetch(project, projectData);

                    projectDataList.Add(projectData);
                }

                return projectDataList.ToArray();
            }
        }

        public ProjectData Create()
        {
            return new ProjectData();
        }

        public ProjectData Update(ProjectData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var project =
                    new Project
                    {
                        ProjectId = data.ProjectId
                    };

                ctx.ObjectContext.Projects.Attach(project);

                DataMapper.Map(data, project);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public ProjectData Insert(ProjectData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var project = new Project();

                DataMapper.Map(data, project);

                ctx.ObjectContext.AddToProjects(project);

                ctx.ObjectContext.SaveChanges();

                data.ProjectId = project.ProjectId;

                return data;
            }
        }

        public void Delete(ProjectDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var project = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Projects.DeleteObject(project);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Project project, ProjectData projectData)
        {
            DataMapper.Map(project, projectData);

            projectData.CreatedByUser = new UserData();
            DataMapper.Map(project.CreatedByUser, projectData.CreatedByUser);

            projectData.ModifiedByUser = new UserData();
            DataMapper.Map(project.ModifiedByUser, projectData.ModifiedByUser);
        }

        private IQueryable<Project> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             ProjectDataCriteria criteria)
        {
            IQueryable<Project> query = ctx.ObjectContext.Projects
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.ProjectId != null)
            {
                query = query.Where(row => row.ProjectId == criteria.ProjectId);
            }

            if (criteria.Description != null)
            {
                query = query.Where(row => row.Description == criteria.Description);
            }

            if (criteria.IsActive != null)
            {
                query = query.Where(row => row.IsActive == criteria.IsActive);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.UserId != null)
            {
                query = query.Join(
                    ctx.ObjectContext.ProjectUserMembers.Where(pum => pum.UserId == criteria.UserId),
                    p => p.ProjectId,
                    pum => pum.ProjectId,
                    (p, cssm) => p);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.ModifiedBy != null)
            {
                query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.Text != null)
            {
                query = query.Where(row => row.Name.Contains(criteria.Text));
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
