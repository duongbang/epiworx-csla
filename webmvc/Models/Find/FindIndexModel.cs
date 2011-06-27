using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{
    public class FindIndexModel : ModelBase
    {
        [Required(ErrorMessage = "Enter your search terms")]
        public string FindText { get; set; }
        public IEnumerable<FindResult> FindResults { get; set; }
        public bool ShowScope { get; set; }

        public FindIndexModel()
        {
            this.Title = "Advanced Find";
            this.ShowScope = false;
            this.FindResults = new List<FindResult>();
        }
    }
}