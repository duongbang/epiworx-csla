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
                case "ProjectId":
                    this.OnProjectIdChanged();
                    break;
                case "SprintId":
                    this.OnSprintIdChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnProjectIdChanged()
        {
            this.ProjectName = DataHelper.FetchProjectName(this.ProjectId);
        }

        private void OnSprintIdChanged()
        {
            this.SprintName = DataHelper.FetchSprintName(this.SprintId);
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
