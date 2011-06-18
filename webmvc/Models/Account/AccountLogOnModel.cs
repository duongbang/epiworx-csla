using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Models
{
    public class AccountLogOnModel : ModelBase
    {
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public AccountLogOnModel()
        {
            this.Title = "Log On";
        }
    }
}