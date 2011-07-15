using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class OrganizationUserFormModel : ModelBase
    {
        public OrganizationUser OrganizationUser { get; set; }
        public IEnumerable<UserInfo> Users { get; set; }
        public IEnumerable<OrganizationUserInfo> OrganizationUsers { get; set; }

        public OrganizationUserFormModel()
        {
        }
    }
}