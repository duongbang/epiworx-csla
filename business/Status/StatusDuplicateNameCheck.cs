using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Epiworx.Data;

namespace Epiworx.Business
{
    public class StatusDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IStatus)context.Target;

            if (string.IsNullOrEmpty(target.Name))
            {
                return;
            }

            var data = StatusInfoList.FetchStatusInfoList(new StatusDataCriteria
                {
                    Name = target.Name,
                    ProjectId = target.ProjectId
                });

            if (data.Count(row => row.StatusId != target.StatusId) != 0)
            {
                context.AddErrorResult(string.Format("The status name '{0}' is already in use.", target.Name));
            }
        }
    }
}
