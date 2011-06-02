using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserPasswordResetRequest
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

        internal static UserPasswordResetRequest FetchUserPasswordResetRequest(UserPasswordResetRequestDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<UserPasswordResetRequest>(criteria);
        }
    }
}
