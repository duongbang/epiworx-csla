using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Epiworx.WebMvc.Core
{
    public class ParameterCollection : List<Parameter>
    {
        public Parameter this[string key]
        {
            get { return this.SingleOrDefault(row => row.Key == key); }
        }

        public ParameterCollection()
        {
        }

        public ParameterCollection(string text)
        {
            var pairs = text.Split(':');

            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            text = text.Replace("=", ":");

            for (var index = 0; index < pairs.Length - 1; index++)
            {
                var pair = pairs[index].Trim();
                string key;
                string value;

                if (pair.IndexOf(" ") == -1)
                {
                    key = pair;
                }
                else
                {
                    key = pair.Substring(pair.IndexOf(" "), pair.Length - pair.IndexOf(" "));
                }

                if (pairs[index + 1].IndexOf(" ") == -1)
                {
                    value = pairs[index + 1];
                }
                else
                {
                    value = pairs[index + 1].Substring(0, pairs[index + 1].IndexOf(" "));
                }

                key = key.Trim();
                value = value.Trim();

                if (key == "find")
                {
                    switch (value.ToLower())
                    {
                        case "h":
                        case "hour":
                        case "hours":
                            value = "Hour";
                            break;
                        case "p":
                        case "project":
                        case "projects":
                            value = "Project";
                            break;
                        case "s":
                        case "story":
                        case "stories":
                            value = "Story";
                            break;
                        case "u":
                        case "user":
                        case "users":
                            value = "User";
                            break;
                    }
                }

                this.Add(new Parameter { Key = key.ToLower(), Value = value });
            }
        }

        public ParameterCollection(IEnumerable<Parameter> parameters, params string[] ignoreList)
        {
            foreach (var parameter in parameters
                .Where(parameter => !ignoreList.Contains(parameter.Key)))
            {
                this.Add(parameter);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var child in this)
            {
                if (sb.Length != 0)
                {
                    sb.Append("&");
                }

                sb.AppendFormat("{0}={1}", child.Key.ToLower(), child.Value);
            }

            return sb.ToString();
        }
    }
}