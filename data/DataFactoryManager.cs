using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public class DataFactoryManager
    {
        private static Type _dataFactoryType;

        public static IDataFactoryManager GetManager()
        {
            if (_dataFactoryType == null)
            {
                var dataFactoryTypeName = ConfigurationManager.AppSettings["DataFactoryManagerType"];

                if (!string.IsNullOrEmpty(dataFactoryTypeName))
                {
                    _dataFactoryType = Type.GetType(dataFactoryTypeName);
                }
                else
                {
                    throw new NullReferenceException("DataFactoryManagerType");
                }

                if (_dataFactoryType == null)
                {
                    throw new ArgumentException(string.Format("Type {0} could not be found", dataFactoryTypeName));
                }
            }

            return (IDataFactoryManager)Activator.CreateInstance(_dataFactoryType);
        }
    }
}
