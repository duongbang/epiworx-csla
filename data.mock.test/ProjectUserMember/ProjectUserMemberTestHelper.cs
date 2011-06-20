using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Test.Helpers;

namespace Epiworx.Test.Helpers
{
    public class ProjectUserTestHelper
    {
        public static ProjectUser ProjectUserAdd()
        {
            var projectUserMember = ProjectUserTestHelper.ProjectUserNew();

            projectUserMember = ProjectUserRepository.ProjectUserSave(projectUserMember);

            return projectUserMember;
        }

        public static ProjectUser ProjectUserNew()
        {
            return ProjectUserTestHelper.ProjectUserNew(Role.Collaborator);
        }

        public static ProjectUser ProjectUserNew(Role roleId)
        {
            var project = ProjectTestHelper.ProjectAdd();
            var user = UserTestHelper.UserAdd();

            var projectUserMember = ProjectUserRepository.ProjectUserNew(project.ProjectId, user.UserId);

            projectUserMember.RoleId = (int)roleId;

            return projectUserMember;
        }
    }
}