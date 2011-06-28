﻿using System;
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

        public static ProjectUser ProjectUserFetch(int projectUserMemberId)
        {
            return ProjectUser.FetchProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectUserMemberId
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

        public static ProjectUser ProjectUserSave(ProjectUser projectUserMember)
        {
            if (!projectUserMember.IsValid)
            {
                return projectUserMember;
            }

            ProjectUserRepository.AuthorizeProjectUser(projectUserMember.ProjectId);

            ProjectUser result;

            if (projectUserMember.IsNew)
            {
                result = ProjectUserRepository.ProjectUserInsert(projectUserMember);
            }
            else
            {
                result = ProjectUserRepository.ProjectUserUpdate(projectUserMember);
            }

            return result;
        }

        public static ProjectUser ProjectUserInsert(ProjectUser projectUserMember)
        {
            projectUserMember = projectUserMember.Save();

            FeedRepository.FeedAdd(FeedAction.Created, projectUserMember);

            return projectUserMember;
        }

        public static ProjectUser ProjectUserUpdate(ProjectUser projectUserMember)
        {
            projectUserMember = projectUserMember.Save();

            FeedRepository.FeedAdd(FeedAction.Edited, projectUserMember);

            return projectUserMember;
        }

        public static ProjectUser ProjectUserAdd(int projectId, int userId, Role role)
        {
            var projectUserMember = ProjectUser.NewProjectUser(projectId, userId);

            projectUserMember.RoleId = (int)role;

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            return projectUserMember;
        }

        internal static ProjectUser ProjectUserAdd(int projectId, int userId, Role role, bool ignoreAuthorization)
        {
            var projectUserMember = ProjectUser.NewProjectUser(projectId, userId);

            projectUserMember.RoleId = (int)role;

            if (ignoreAuthorization)
            {
                projectUserMember = ProjectUserRepository.ProjectUserInsert(projectUserMember);
            }
            else
            {
                projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);
            }

            return projectUserMember;
        }

        public static ProjectUser ProjectUserNew(int projectId, int userId)
        {
            var projectUserMember = ProjectUser.NewProjectUser(projectId, userId);

            return projectUserMember;
        }

        public static bool ProjectUserDelete(ProjectUser projectUserMember)
        {
            ProjectUserRepository.AuthorizeProjectUser(projectUserMember.ProjectId);

            if (ProjectUserRepository.ProjectUserFetch(
                projectUserMember.ProjectId, projectUserMember.UserId).RoleId == (int)Role.Owner)
            {
                throw new NotSupportedException("You cannot delete the owner of a project");
            }

            ProjectUser.DeleteProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectUserMember.ProjectUserMemberId
                });

            FeedRepository.FeedAdd(FeedAction.Deleted, projectUserMember);

            return true;
        }

        public static bool ProjectUserDelete(int projectId)
        {
            return ProjectUserRepository.ProjectUserDelete(
                ProjectUserRepository.ProjectUserFetch(projectId));
        }
    }
}
