using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Rules;
using Epiworx.Data;

namespace Epiworx.Business
{
    public class CategoryDuplicateNameCheck : BusinessRule
    {
        protected override void Execute(RuleContext context)
        {
            var target = (ICategory)context.Target;

            if (string.IsNullOrEmpty(target.Name))
            {
                return;
            }

            var data = CategoryInfoList.FetchCategoryInfoList(new CategoryDataCriteria
                {
                    Name = target.Name
                });

            if (data.Count(row => row.CategoryId != target.CategoryId) != 0)
            {
                context.AddErrorResult(string.Format("The category name '{0}' is already in use.", target.Name));
            }
        }
    }
}
