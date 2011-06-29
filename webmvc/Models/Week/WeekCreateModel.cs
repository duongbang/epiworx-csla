using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;

namespace Epiworx.WebMvc.Models
{

    public class WeekCreateModel : ModelBase
    {
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Number of periods is required")]
        public int NumberOfPeriods { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        public WeekCreateModel()
        {
            this.NumberOfPeriods = 13;
            this.Year = DateTime.Now.Year;
        }
    }
}