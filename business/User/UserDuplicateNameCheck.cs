using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Epiworx.Data;

namespace Epiworx.Business
{
    public class UserDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IUser)context.Target;

            if (string.IsNullOrEmpty(target.Name))
            {
                return;
            }

            var data = UserInfoList.FetchUserInfoList(new UserDataCriteria
                {
                    Name = target.Name
                });

            if (data.Count(row => row.UserId != target.UserId) != 0)
            {
                context.AddErrorResult(string.Format("The user name '{0}' is already in use.", target.Name));
            }
        }
    }
}
