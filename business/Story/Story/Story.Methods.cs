using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Story
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Description);
        }

        public StoryInfo ToStoryInfo()
        {
            var result = new StoryInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                case "AssignedTo":
                    this.OnAssignedToChanged();
                    break;
                case "ProjectId":
                    this.OnProjectIdChanged();
                    break;
                case "SprintId":
                    this.OnSprintIdChanged();
                    break;
                case "StatusId":
                    this.OnStatusIdChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnAssignedToChanged()
        {
            this.AssignedToName = DataHelper.FetchUserName(this.AssignedTo);

            if (this.AssignedTo == 0)
            {
                this.AssignedDate = DateTime.MaxValue.Date;

                return;
            }

            this.AssignedDate = DateTime.Now;
        }

        private void OnProjectIdChanged()
        {
            this.ProjectName = DataHelper.FetchProjectName(this.ProjectId);
        }

        private void OnSprintIdChanged()
        {
            this.SprintName = DataHelper.FetchSprintName(this.SprintId);
        }

        private void OnStatusIdChanged()
        {
            if (this.StatusId == 0)
            {
                this.IsCompleted = false;
                this.StatusName = string.Empty;
                this.StartDate = DateTime.MaxValue.Date;
                this.CompletedDate = DateTime.MaxValue.Date;

                return;
            }

            var status = Status.FetchStatus(new StatusDataCriteria { StatusId = this.StatusId });

            this.StatusName = status.Name;

            if (status.IsStarted)
            {
                this.CompletedDate = DateTime.MaxValue.Date;
                this.StartDate = DateTime.Now.Date;
            }
            else if (status.IsCompleted)
            {
                this.CompletedDate = DateTime.MaxValue.Date;
            }
            else
            {
                this.StartDate = DateTime.MaxValue.Date;
                this.CompletedDate = DateTime.MaxValue.Date;
            }
        }

        internal static Story NewStory()
        {
            return Csla.DataPortal.Create<Story>();
        }

        internal static Story FetchStory(StoryDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Story>(criteria);
        }

        internal static Story FetchStory(StoryData data)
        {
            var result = new Story();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteStory(StoryDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Story>(criteria);
        }
    }
}
