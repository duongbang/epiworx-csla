using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Epiworx.Business;

namespace Epiworx.WcfRestService
{
    public class ProjectData
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
        public string Name { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserData ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<TimelineData> Timelines { get; set; }
        public List<BrokenRuleData> BrokenRules { get; set; }

        public ProjectData()
        {
            this.CreatedBy = new UserData();
            this.ModifiedBy = new UserData();
            this.BrokenRules = new List<BrokenRuleData>();
            this.Timelines = new List<TimelineData>();
        }

        public ProjectData(Project project)
            : this()
        {
            this.ProjectId = project.ProjectId;
            this.Description = project.Description;
            this.IsActive = project.IsActive;
            this.IsArchived = project.IsArchived;
            this.Name = project.Name;
            this.CreatedBy = new UserData(project.CreatedBy, string.Empty, string.Empty);
            this.CreatedDate = project.CreatedDate;
            this.ModifiedBy = new UserData(project.ModifiedBy, string.Empty, string.Empty);
            this.ModifiedDate = project.ModifiedDate;

            foreach (var brokenRule in project.BrokenRulesCollection)
            {
                this.BrokenRules.Add(new BrokenRuleData(brokenRule));
            }
        }

        public ProjectData(ProjectInfo project)
            : this()
        {
            this.ProjectId = project.ProjectId;
            this.Description = project.Description;
            this.IsActive = project.IsActive;
            this.IsArchived = project.IsArchived;
            this.Name = project.Name;
            this.CreatedBy = new UserData(project.CreatedBy, string.Empty, string.Empty);
            this.CreatedDate = project.CreatedDate;
            this.ModifiedBy = new UserData(project.ModifiedBy, string.Empty, string.Empty);
            this.ModifiedDate = project.ModifiedDate;
        }
    }
}
