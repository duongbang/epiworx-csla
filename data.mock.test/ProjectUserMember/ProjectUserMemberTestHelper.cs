using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Test.Helpers;

namespace Epiworx.Test.Helpers
{
    public class ProjectUserMemberTestHelper
    {
        public static ProjectUserMember ProjectUserMemberAdd()
        {
            var projectUserMember = ProjectUserMemberTestHelper.ProjectUserMemberNew();

            projectUserMember = ProjectUserMemberRepository.ProjectUserMemberSave(projectUserMember);

            return projectUserMember;
        }

        public static ProjectUserMember ProjectUserMemberNew()
        {
            return ProjectUserMemberTestHelper.ProjectUserMemberNew(Role.Administrator);
        }

        public static ProjectUserMember ProjectUserMemberNew(Role RoleId)
        {
            var project = ProjectTestHelper.ProjectAdd();
            var user = UserTestHelper.UserAdd();

            var projectUserMember = ProjectUserMemberRepository.ProjectUserMemberNew(project.ProjectId, user.UserId);

            projectUserMember.RoleId = (int)RoleId;

            return projectUserMember;
        }
    }
}

