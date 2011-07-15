using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Epiworx.Data;

namespace Epiworx.Business
{
    public class ProjectUserDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IProjectUser)context.Target;

            if (target.ProjectId == 0 || target.UserId == 0)
            {
                return;
            }

            var data = ProjectUserInfoList.FetchProjectUserInfoList(
                new ProjectUserMemberDataCriteria
                    {
                        ProjectId = target.ProjectId,
                        UserId = target.UserId
                    });

            if (data.Count(row => row.ProjectId != target.ProjectId && row.UserId != target.UserId) != 0)
            {
                context.AddErrorResult(string.Format("The project '{0}' and user '{1}' is already in use.", target.ProjectName, target.UserName));
            }
        }
    }
}
