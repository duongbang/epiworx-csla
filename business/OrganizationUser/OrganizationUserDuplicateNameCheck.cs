using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Epiworx.Data;

namespace Epiworx.Business
{
    public class OrganizationUserDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IOrganizationUser)context.Target;

            if (target.OrganizationId == 0 || target.UserId == 0)
            {
                return;
            }

            var data = OrganizationUserInfoList.FetchOrganizationUserInfoList(new OrganizationUserMemberDataCriteria
                {
                    OrganizationId = target.OrganizationId,
                    UserId = target.UserId
                });

            if (data.Count(row => row.OrganizationId != target.OrganizationId && row.UserId != target.UserId) != 0)
            {
                context.AddErrorResult(string.Format("The organization '{0}' and user '{1}' is already in use.", target.OrganizationName, target.UserName));
            }
        }
    }
}
