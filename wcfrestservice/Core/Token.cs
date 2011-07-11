using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WcfRestService
{
    public class Token
    {
        public string Key { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}