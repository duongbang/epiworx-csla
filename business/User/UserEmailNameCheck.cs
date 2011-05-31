using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Epiworx.Data;

namespace Epiworx.Business
{
    public class UserDuplicateEmailCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (IUser)context.Target;

            if (string.IsNullOrEmpty(target.Email))
            {
                return;
            }

            var data = UserInfoList.FetchUserInfoList(new UserDataCriteria
                {
                    Email = target.Email
                });

            if (data.Count(row => row.UserId != target.UserId) != 0)
            {
                context.AddErrorResult(string.Format("The user email '{0}' is already in use.", target.Email));
            }
        }
    }
}
