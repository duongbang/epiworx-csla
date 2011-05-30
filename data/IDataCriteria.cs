using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public interface IDataCriteria
    {
        string Text { get; set; }
        int? SkipRecords { get; set; }
        int? MaximumRecords { get; set; }
        string SortBy { get; set; }
        ListSortDirection SortOrder { get; set; }
    }
}
