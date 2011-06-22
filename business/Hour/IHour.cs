using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IHour
    {
        int HourId { get; }
        DateTime Date { get; }
        decimal Duration { get; }
        bool IsArchived { get; }
        string Notes { get; }
        int ProjectId { get; }
        string ProjectName { get; }
        int StoryId { get; }
        int UserId { get; }
        string UserName { get; }
        int CreatedBy { get; }
        DateTime CreatedDate { get; }
        int ModifiedBy { get; }
        DateTime ModifiedDate { get; }
    }
}
