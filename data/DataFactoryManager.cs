using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public class DataFactoryManager
    {
        private static Type DataFactoryType { get; set; }

        public static IDataFactoryManager GetManager()
        {
            if (DataFactoryType == null)
            {
                var dataFactoryTypeName = ConfigurationManager.AppSettings["DataFactoryManagerType"];

                if (!string.IsNullOrEmpty(dataFactoryTypeName))
                {
                    DataFactoryType = Type.GetType(dataFactoryTypeName);
                }
                else
                {
                    throw new NullReferenceException("DataFactoryManagerType");
                }

                if (DataFactoryType == null)
                {
                    throw new ArgumentException(string.Format("Type {0} could not be found", dataFactoryTypeName));
                }
            }

            return (IDataFactoryManager)Activator.CreateInstance(DataFactoryType);
        }
    }
}
