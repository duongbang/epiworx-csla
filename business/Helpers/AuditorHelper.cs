using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Epiworx.Business.Helpers
{
    public class AuditorHelper
    {
        public static XmlTextWriter Audit<T>(
           XmlTextWriter writer,
           string name,
           T value,
           T valueToCompare)
        {
            if (value.Equals(valueToCompare))
            {
                return writer;
            }

            var oldValue = value.ToString();
            var newValue = valueToCompare.ToString();

            if (value.GetType() == typeof(bool))
            {
                oldValue = bool.Parse(oldValue) ? "Yes" : "No";
                newValue = bool.Parse(newValue) ? "Yes" : "No";
            }
            else if (value.GetType() == typeof(int))
            {
                oldValue = decimal.Parse(oldValue).ToString("N0");
                newValue = decimal.Parse(newValue).ToString("N0");
            }
            else if (value.GetType() == typeof(decimal))
            {
                oldValue = decimal.Parse(oldValue).ToString("N2");
                newValue = decimal.Parse(newValue).ToString("N2");
            }
            else if (value.GetType() == typeof(DateTime))
            {
                oldValue = DateTime.Parse(oldValue).ToShortDateString();
                newValue = DateTime.Parse(newValue).ToShortDateString();
            }

            writer.WriteStartElement("Change");

            writer.WriteElementString("Name", name);
            writer.WriteElementString("OldValue", oldValue);
            writer.WriteElementString("NewValue", newValue);

            writer.WriteEndElement();

            return writer;
        }
    }
}
