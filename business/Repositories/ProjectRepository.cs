using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    using Epiworx.Business.Security;

    [Serializable]
    public class ProjectRepository
    {
        public static Project ProjectFetch(int projectId)
        {
            return Project.FetchProject(
                new ProjectDataCriteria
                {
                    ProjectId = projectId
                });
        }

        public static ProjectInfoList ProjectFetchInfoList()
        {
            return ProjectRepository.ProjectFetchInfoList(new ProjectDataCriteria());
        }

        public static ProjectInfoList ProjectFetchInfoList(ProjectDataCriteria criteria)
        {
            // this will ensure that users can only view projects that they are assigned to
            criteria.UserId = ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

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

            ProjectUserRepository.ProjectUserAdd(
                project.ProjectId, ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId, Role.Owner);

            SourceRepository.SourceAdd(project.ProjectId, SourceType.Project, project.Name);

            return project;
        }

        public static Project ProjectUpdate(Project project)
        {
            project = project.Save();

            SourceRepository.SourceUpdate(project.ProjectId, SourceType.Project, project.Name);

            return project;
        }

        public static Project ProjectNew()
        {
            var project = Project.NewProject();

            return project;
        }

        public static bool ProjectDelete(Project project)
        {
            Project.DeleteProject(
                new ProjectDataCriteria
                {
                    ProjectId = project.ProjectId
                });

            SourceRepository.SourceDelete(project.ProjectId, SourceType.Project);

            return true;
        }

        public static bool ProjectDelete(int projectId)
        {
            return ProjectRepository.ProjectDelete(
                ProjectRepository.ProjectFetch(projectId));
        }
    }
}
