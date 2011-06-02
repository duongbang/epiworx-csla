using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserPasswordReset
    {
        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static UserPasswordReset FetchUserPasswordReset(UserPasswordResetDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<UserPasswordReset>(criteria);
        }
    }
}
