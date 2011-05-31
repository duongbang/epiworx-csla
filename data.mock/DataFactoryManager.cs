using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class DataFactoryManager : IDataFactoryManager
    {
        private static string _typeMask = typeof(DataFactoryManager).FullName.Replace("DataFactoryManager", @"{0}");

        public T GetProvider<T>() where T : class
        {
            var typeName = string.Format(_typeMask, typeof(T).Name.Substring(1));
            var type = Type.GetType(typeName);

            if (type != null)
            {
                return Activator.CreateInstance(type) as T;
            }

            throw new NotImplementedException(typeName);
        }

        public void Dispose()
        {
        }
    }
}
