using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Principal;

namespace Epiworx.Business.Security
{
    public partial class BusinessIdentity
    {
        public int UserId { get; internal set; }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public string Email { get; internal set; }
        public string FullName { get; internal set; }
        public bool IsAuthenticated { get; internal set; }
        public string Name { get; internal set; }
        public List<BusinessIdentityProject> Projects { get; internal set; }
    }
}
