using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class UserListModel : ModelBase
    {
        public IEnumerable<UserInfo> Users { get; set; }

        public UserListModel()
        {
        }
    }
}