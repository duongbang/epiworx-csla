using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;

namespace Epiworx.Business.Security
{
    [Serializable]
    public partial class BusinessIdentityProject : Csla.ReadOnlyBase<BusinessIdentityProject>, IBusinessIdentityProject
    {
        private BusinessIdentityProject()
        {
        }
    }
}
