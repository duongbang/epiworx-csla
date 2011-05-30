using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data
{
    public interface IDataFactoryManager : IDisposable
    {
        T GetProvider<T>() where T : class;
    }
}
