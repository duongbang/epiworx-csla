using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    using System.Security;

    using Epiworx.Business.Security;

    [Serializable]
    public class ProjectRepository
    {
        public static Project ProjectFetch(int projectId)
        {
            ProjectUserRepository.AuthorizeProjectUser(projectId);

            var result = Project.FetchProject(
                new ProjectDataCriteria
                {
                    ProjectId = projectId
                });

            result.Auditor = new ProjectAuditor(result.Clone());

            return result;
        }

        public static ProjectInfoList ProjectFetchInfoList()
        {
            return ProjectRepository.ProjectFetchInfoList(new ProjectDataCriteria());
        }

        public static ProjectInfoList ProjectFetchInfoList(ProjectDataCriteria criteria)
        {
            // this will ensure that users can only view projects that they are assigned to
            criteria.UserId =
                ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

            return ProjectInfoList.FetchProjectInfoList(criteria);
        }

        public static Project ProjectSave(Project project)
        {
            if (!project.IsValid)
            {
                return project;
            }

            Project result;

            if (project.IsNew)
            {
                result = ProjectRepository.ProjectInsert(project);
            }
            else
            {
                result = ProjectRepository.ProjectUpdate(project);
            }

            return result;
        }

        public static Project ProjectInsert(Project project)
        {
            project = project.Save();

            SourceRepository.SourceAdd(project.ProjectId, SourceType.Project, project.Name);

            FeedRepository.FeedAdd(FeedAction.Created, project);

            ProjectUserRepository.ProjectUserAdd(
                project.ProjectId, ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId, Role.Owner, true);

            return project;
        }

        public static Project ProjectUpdate(Project project)
        {
            if (!project.IsDirty)
            {
                return project;
            }

            ProjectUserRepository.AuthorizeProjectUser(project.ProjectId);

            project = project.Save();

            SourceRepository.SourceUpdate(project.ProjectId, SourceType.Project, project.Name);

            FeedRepository.FeedAdd(FeedAction.Edited, project);

            return project;
        }

        public static Project ProjectNew()
        {
            var project = Project.NewProject();

            return project;
        }

        public static bool ProjectDelete(Project project)
        {
            ProjectUserRepository.AuthorizeProjectUser(project.ProjectId);

            Project.DeleteProject(
                new ProjectDataCriteria
                {
                    ProjectId = project.ProjectId
                });

            FeedRepository.FeedAdd(FeedAction.Deleted, project);

            return true;
        }

        public static bool ProjectDelete(int projectId)
        {
            return ProjectRepository.ProjectDelete(
                ProjectRepository.ProjectFetch(projectId));
        }
    }
}
