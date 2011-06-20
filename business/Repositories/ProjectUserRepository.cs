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
    public class ProjectUserRepository
    {
        public static ProjectUser ProjectUserFetch(int projectId)
        {
            return ProjectUser.FetchProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectId
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

            return projectUserMember;
        }

        public static ProjectUser ProjectUserUpdate(ProjectUser projectUserMember)
        {
            projectUserMember = projectUserMember.Save();

            return projectUserMember;
        }

        public static ProjectUser ProjectUserAdd(int projectId, int userId, Role role)
        {
            var projectUserMember = ProjectUser.NewProjectUser(projectId, userId);

            projectUserMember.RoleId = (int)role;

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            return projectUserMember;
        }

        public static ProjectUser ProjectUserNew(int projectId, int userId)
        {
            var projectUserMember = ProjectUser.NewProjectUser(projectId, userId);

            return projectUserMember;
        }

        public static bool ProjectUserDelete(ProjectUser projectUserMember)
        {
            ProjectUser.DeleteProjectUser(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectUserMember.ProjectUserMemberId
                });

            return true;
        }

        public static bool ProjectUserDelete(int projectId)
        {
            return ProjectUserRepository.ProjectUserDelete(
                ProjectUserRepository.ProjectUserFetch(projectId));
        }
    }
}
