using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class ProjectUserRepository
    {
        public static void AuthorizeProjectUser(int projectId)
        {
            var userId =
                ((IBusinessIdentity)Csla.ApplicationContext.User.Identity).UserId;

            ProjectUserRepository.AuthorizeProjectUser(projectId, userId);
        }

        public static void AuthorizeProjectUser(int projectId, int userId)
        {
            var projects = ProjectRepository.ProjectFetchInfoList();

            if (!projects.Any(project => project.ProjectId == projectId))
            {
                throw new SecurityException("You are not a member of this project.");
            }
        }

        public static ProjectUser ProjectUserFetch(int projectUserId)
        {
            return ProjectUser.FetchProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectUserId
                });
        }

        public static ProjectUser ProjectUserFetch(int projectId, int userId)
        {
            return ProjectUser.FetchProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectId = projectId,
                    UserId = userId
                });
        }

        public static ProjectUserInfoList ProjectUserFetchInfoList(int projectId)
        {
            ProjectUserRepository.AuthorizeProjectUser(projectId);

            return ProjectUserInfoList.FetchProjectUserInfoList(
                new ProjectUserMemberDataCriteria
                    {
                        ProjectId = projectId
                    });
        }

        public static ProjectUserInfoList ProjectUserFetchInfoList(ProjectUserMemberDataCriteria criteria)
        {
            return ProjectUserInfoList.FetchProjectUserInfoList(criteria);
        }

        public static ProjectUser ProjectUserSave(ProjectUser projectUser)
        {
            if (!projectUser.IsValid)
            {
                return projectUser;
            }

            ProjectUserRepository.AuthorizeProjectUser(projectUser.ProjectId);

            ProjectUser result;

            if (projectUser.IsNew)
            {
                result = ProjectUserRepository.ProjectUserInsert(projectUser);
            }
            else
            {
                result = ProjectUserRepository.ProjectUserUpdate(projectUser);
            }

            return result;
        }

        public static ProjectUser ProjectUserInsert(ProjectUser projectUser)
        {
            projectUser = projectUser.Save();

            SourceRepository.SourceAdd(projectUser.ProjectUserMemberId, SourceType.ProjectUser, string.Empty);

            FeedRepository.FeedAdd(FeedAction.Created, projectUser);

            return projectUser;
        }

        public static ProjectUser ProjectUserUpdate(ProjectUser projectUser)
        {
            if (!projectUser.IsDirty)
            {
                return projectUser;
            }

            projectUser = projectUser.Save();

            SourceRepository.SourceUpdate(projectUser.ProjectUserMemberId, SourceType.ProjectUser, string.Empty);

            FeedRepository.FeedAdd(FeedAction.Edited, projectUser);

            return projectUser;
        }

        public static ProjectUser ProjectUserAdd(int projectId, int userId, Role role)
        {
            var projectUser = ProjectUser.NewProjectUser(projectId, userId);

            projectUser.RoleId = (int)role;

            projectUser = ProjectUserRepository.ProjectUserSave(projectUser);

            return projectUser;
        }

        internal static ProjectUser ProjectUserAdd(int projectId, int userId, Role role, bool ignoreAuthorization)
        {
            var projectUser = ProjectUser.NewProjectUser(projectId, userId);

            projectUser.RoleId = (int)role;

            if (ignoreAuthorization)
            {
                projectUser = ProjectUserRepository.ProjectUserInsert(projectUser);
            }
            else
            {
                projectUser = ProjectUserRepository.ProjectUserSave(projectUser);
            }

            return projectUser;
        }

        public static ProjectUser ProjectUserNew(int projectId, int userId)
        {
            var projectUser = ProjectUser.NewProjectUser(projectId, userId);

            return projectUser;
        }

        public static bool ProjectUserDelete(ProjectUser projectUser)
        {
            ProjectUserRepository.AuthorizeProjectUser(projectUser.ProjectId);

            if (ProjectUserRepository.ProjectUserFetch(
                projectUser.ProjectId, projectUser.UserId).RoleId == (int)Role.Owner)
            {
                throw new NotSupportedException("You cannot delete the owner of a project");
            }

            ProjectUser.DeleteProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectUser.ProjectUserMemberId
                });

            FeedRepository.FeedAdd(FeedAction.Deleted, projectUser);

            return true;
        }

        public static bool ProjectUserDelete(int projectId)
        {
            return ProjectUserRepository.ProjectUserDelete(
                ProjectUserRepository.ProjectUserFetch(projectId));
        }
    }
}
