using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    [Serializable]
    public class HourAuditor : IAuditor<Hour>
    {
        public Hour Object { get; internal set; }

        public string Audit(Hour obj)
        {
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Changes");

            xmlWriter = AuditorHelper.Audit(xmlWriter, "Date", this.Object.Date, obj.Date);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Duration", this.Object.Duration, obj.Duration);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsArchived", this.Object.IsArchived, obj.IsArchived);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Notes", this.Object.Notes, obj.Notes);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            return stringWriter.ToString();
        }

        public HourAuditor(Hour obj)
        {
            this.Object = obj;
        }
    }
}
