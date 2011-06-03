using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Sprint
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        public SprintInfo ToSprintInfo()
        {
            var result = new SprintInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static Sprint NewSprint(int projectId)
        {
            return Csla.DataPortal.Create<Sprint>(
                new SprintDataCriteria
                {
                    ProjectId = projectId
                });
        }

        internal static Sprint FetchSprint(SprintDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Sprint>(criteria);
        }

        internal static Sprint FetchSprint(SprintData data)
        {
            var result = new Sprint();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteSprint(SprintDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Sprint>(criteria);
        }
    }
}
