using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Project
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        public ProjectInfo ToProjectInfo()
        {
            var result = new ProjectInfo();

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

        internal static Project NewProject()
        {
            return Csla.DataPortal.Create<Project>();
        }

        internal static Project FetchProject(ProjectDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Project>(criteria);
        }

        internal static Project FetchProject(ProjectData data)
        {
            var result = new Project();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteProject(ProjectDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Project>(criteria);
        }
    }
}
