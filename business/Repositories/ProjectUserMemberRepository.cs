using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class ProjectUserMemberRepository
    {
        public static ProjectUserMember ProjectUserMemberFetch(int projectId)
        {
            return ProjectUserMember.FetchProjectUserMember(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectId
                });
        }

        public static ProjectUserMemberInfoList ProjectUserMemberFetchInfoList(ProjectUserMemberDataCriteria criteria)
        {
            return ProjectUserMemberInfoList.FetchProjectUserMemberInfoList(criteria);
        }

        public static ProjectUserMember ProjectUserMemberSave(ProjectUserMember projectUserMember)
        {
            if (!projectUserMember.IsValid)
            {
                return projectUserMember;
            }

            ProjectUserMember result;

            if (projectUserMember.IsNew)
            {
                result = ProjectUserMemberRepository.ProjectUserMemberInsert(projectUserMember);
            }
            else
            {
                result = ProjectUserMemberRepository.ProjectUserMemberUpdate(projectUserMember);
            }

            return result;
        }

        public static ProjectUserMember ProjectUserMemberInsert(ProjectUserMember projectUserMember)
        {
            projectUserMember = projectUserMember.Save();

            return projectUserMember;
        }

        public static ProjectUserMember ProjectUserMemberUpdate(ProjectUserMember projectUserMember)
        {
            projectUserMember = projectUserMember.Save();

            return projectUserMember;
        }

        public static ProjectUserMember ProjectUserMemberNew(int projectId, int userId)
        {
            var projectUserMember = ProjectUserMember.NewProjectUserMember(projectId, userId);

            return projectUserMember;
        }

        public static bool ProjectUserMemberDelete(ProjectUserMember projectUserMember)
        {
            ProjectUserMember.DeleteProjectUserMember(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = projectUserMember.ProjectUserMemberId
                });

            return true;
        }

        public static bool ProjectUserMemberDelete(int projectId)
        {
            return ProjectUserMemberRepository.ProjectUserMemberDelete(
                ProjectUserMemberRepository.ProjectUserMemberFetch(projectId));
        }
    }
}
