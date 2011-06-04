using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Category
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Name);
        }

        public CategoryInfo ToCategoryInfo()
        {
            var result = new CategoryInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static Category NewCategory()
        {
            return Csla.DataPortal.Create<Category>();
        }

        internal static Category FetchCategory(CategoryDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Category>(criteria);
        }

        internal static Category FetchCategory(CategoryData data)
        {
            var result = new Category();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteCategory(CategoryDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Category>(criteria);
        }
    }
}
