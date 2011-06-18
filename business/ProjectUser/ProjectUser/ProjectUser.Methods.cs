using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class ProjectUser
    {
        public ProjectUserInfo ToProjectUserInfo()
        {
            var result = new ProjectUserInfo();

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

        internal static ProjectUser NewProjectUser(int projectId, int userId)
        {
            return Csla.DataPortal.Create<ProjectUser>(
                new ProjectUserMemberDataCriteria
                {
                    ProjectId = projectId,
                    UserId = userId
                });
        }

        internal static ProjectUser FetchProjectUser(ProjectUserMemberDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<ProjectUser>(criteria);
        }

        internal static ProjectUser FetchProjectUser(ProjectUserMemberData data)
        {
            var result = new ProjectUser();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteProjectUser(ProjectUserMemberDataCriteria criteria)
        {
            Csla.DataPortal.Delete<ProjectUser>(criteria);
        }
    }
}
