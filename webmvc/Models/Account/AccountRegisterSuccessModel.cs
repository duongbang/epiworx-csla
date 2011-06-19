using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;
using Epiworx.WebMvc.Helpers;

namespace Epiworx.WebMvc.Models
{
    public class AccountRegisterSuccessModel : ModelBase
    {
        public AccountRegisterSuccessModel()
        {
            this.Title = "Registration Complete";
        }
    }
}