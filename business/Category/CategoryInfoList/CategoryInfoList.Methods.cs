using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class CategoryInfoList
    {
        internal static CategoryInfoList FetchCategoryInfoList(CategoryDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<CategoryInfoList>(criteria);
        }
    }
}
