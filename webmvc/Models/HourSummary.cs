using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WebMvc.Models
{
    public class HourSummary
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public double LowValue
        {
            get { return this.NormalValue * .90; }
        }

        public double NormalValue { get; set; }

        public double HighValue
        {
            get { return this.NormalValue * 1.2; }
        }

        public int Percentage
        {
            get { return (int)((this.Value / this.NormalValue) * 100); }
        }
    }
}