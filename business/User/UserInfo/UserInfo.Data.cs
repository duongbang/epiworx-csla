using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class UserInfo
    {
        private void Child_Fetch(UserData data)
        {
		    this.UserId = data.UserId;
		    this.Email = data.Email;
		    this.FullName = data.FullName;
		    this.IsActive = data.IsActive;
		    this.IsArchived = data.IsArchived;
		    this.Name = data.Name;
		    this.Salt = data.Salt;
		    this.Password = data.Password;
		    this.CreatedDate = data.CreatedDate;
		    this.ModifiedDate = data.ModifiedDate;
        }
    }
}
