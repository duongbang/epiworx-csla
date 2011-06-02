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

        public static ProjectUserMember ProjectUserMemberSave(ProjectUserMember project)
        {
            if (!project.IsValid)
            {
                return project;
            }

            ProjectUserMember result;

            if (project.IsNew)
            {
                result = ProjectUserMemberRepository.ProjectUserMemberInsert(project);
            }
            else
            {
                result = ProjectUserMemberRepository.ProjectUserMemberUpdate(project);
            }

            return result;
        }

        public static ProjectUserMember ProjectUserMemberInsert(ProjectUserMember project)
        {
            project = project.Save();

            return project;
        }

        public static ProjectUserMember ProjectUserMemberUpdate(ProjectUserMember project)
        {
            project = project.Save();

            return project;
        }

        public static ProjectUserMember ProjectUserMemberNew(int projectId, int userId)
        {
            var project = ProjectUserMember.NewProjectUserMember(projectId, userId);

            return project;
        }

        public static bool ProjectUserMemberDelete(ProjectUserMember project)
        {
            ProjectUserMember.DeleteProjectUserMember(
                new ProjectUserMemberDataCriteria
                {
                    ProjectUserMemberId = project.ProjectUserMemberId
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
