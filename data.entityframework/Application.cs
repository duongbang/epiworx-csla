using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Epiworx.Data.EntityFramework
{
    public partial class ApplicationEntities
    {
        [EdmFunction("ApplicationModel", "GetSprintDuration")]
        public decimal? GetSprintDuration(int sprintId)
        {
            return this.QueryProvider.Execute<decimal?>(Expression.Call(
                Expression.Constant(this),
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                Expression.Constant(sprintId, typeof(int))));
        }
    }
}
