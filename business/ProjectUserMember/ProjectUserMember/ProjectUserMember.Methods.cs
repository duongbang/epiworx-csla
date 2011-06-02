using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class ProjectUserMember
    {
        public ProjectUserMemberInfo ToProjectUserMemberInfo()
        {
            var result = new ProjectUserMemberInfo();

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

        internal static ProjectUserMember NewProjectUserMember(int projectId, int userId)
        {
            return Csla.DataPortal.Create<ProjectUserMember>(
                new ProjectUserMemberDataCriteria
                {
                    ProjectId = projectId,
                    UserId = userId
                });
        }

        internal static ProjectUserMember FetchProjectUserMember(ProjectUserMemberDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<ProjectUserMember>(criteria);
        }

        internal static ProjectUserMember FetchProjectUserMember(ProjectUserMemberData data)
        {
            var result = new ProjectUserMember();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteProjectUserMember(ProjectUserMemberDataCriteria criteria)
        {
            Csla.DataPortal.Delete<ProjectUserMember>(criteria);
        }
    }
}
