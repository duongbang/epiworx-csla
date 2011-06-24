using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;

namespace Epiworx.Data
{
    [Serializable]
    public class DateRangeCriteria
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public bool HasValue
        {
            get { return this.DateFrom != DateTime.MinValue || this.DateTo != DateTime.MaxValue; }
        }

        public List<DateTime> GetDates()
        {
            var result = new List<DateTime>();

            for (var i = 0; i < this.DateTo.Subtract(this.DateFrom).Days + 1; i++)
            {
                result.Add(this.DateFrom.AddDays(i).Date);
            }

            return result;
        }

        public DateRangeCriteria()
        {
            this.DateFrom = DateTime.MinValue;
            this.DateTo = DateTime.MaxValue;
        }

        public DateRangeCriteria(string range)
        {
            this.DateFrom = DateTime.MinValue;
            this.DateTo = DateTime.MaxValue;

            switch (range.ToLower())
            {
                case "today":
                    this.DateFrom = DateTime.Today.Date;
                    this.DateTo = DateTime.Today.Date;
                    break;
                case "yesterday":
                    this.DateFrom = DateTime.Today.Date.AddDays(-1);
                    this.DateTo = DateTime.Today.Date.AddDays(-1);
                    break;
                case "thisweek":
                    this.DateFrom = DateTime.Today.ToStartOfWeek();
                    this.DateTo = DateTime.Today.ToEndOfWeek();
                    break;
                case "lastweek":
                    this.DateFrom = DateTime.Today.ToStartOfPreviousWeek();
                    this.DateTo = DateTime.Today.ToEndOfPreviousWeek();
                    break;
                case "last10days":
                    this.DateFrom = DateTime.Today.Date.AddDays(-10);
                    this.DateTo = DateTime.Today.Date;
                    break;
                case "last30days":
                    this.DateFrom = DateTime.Today.Date.AddDays(-30);
                    this.DateTo = DateTime.Today.Date;
                    break;
                case "last60days":
                    this.DateFrom = DateTime.Today.Date.AddDays(-60);
                    this.DateTo = DateTime.Today.Date;
                    break;
                case "last90days":
                    this.DateFrom = DateTime.Today.Date.AddDays(-90);
                    this.DateTo = DateTime.Today.Date;
                    break;
                case "thismonth":
                    this.DateFrom = DateTime.Today.ToStartOfMonth();
                    this.DateTo = DateTime.Today.ToEndOfMonth();
                    break;
                case "lastmonth":
                    this.DateFrom = DateTime.Today.ToStartOfPreviousMonth();
                    this.DateTo = DateTime.Today.ToEndOfPreviousMonth();
                    break;
                default:
                    break;
            }
        }

        public DateRangeCriteria(DateTime? dateFrom, DateTime? dateTo)
        {
            this.DateFrom = dateFrom ?? DateTime.MinValue.Date;
            this.DateTo = dateTo ?? DateTime.MaxValue.Date;
        }

        public DateRangeCriteria(int year)
        {
            this.DateFrom = DateTime.Parse(string.Format("1/1/{0}", year));
            this.DateTo = DateTime.Parse(string.Format("12/31/{0}", year));
        }
    }
}
