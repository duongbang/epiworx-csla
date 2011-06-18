using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Console
{
    public class ParameterCollection : List<Parameter>
    {
        public string this[string key]
        {
            get { return this.Where(p => p.Key == key).Single().Value; }
        }

        public ParameterCollection(IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                this.Add(new Parameter { Key = value.Split(':')[0], Value = value.Split(':')[1] });
            }
        }

        public bool Contains(string key)
        {
            return this.Any(p => p.Key == key);
        }
    }
}
