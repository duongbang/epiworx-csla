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
    public class StatusAuditor : IAuditor<Status>
    {
        public Status Object { get; internal set; }

        public string Audit(Status obj)
        {
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Changes");

            xmlWriter = AuditorHelper.Audit(xmlWriter, "Description", this.Object.Description, obj.Description);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsActive", this.Object.IsActive, obj.IsActive);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsArchived", this.Object.IsArchived, obj.IsArchived);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsCompleted", this.Object.IsCompleted, obj.IsCompleted);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsStarted", this.Object.IsStarted, obj.IsStarted);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Name", this.Object.Name, obj.Name);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Ordinal", this.Object.Ordinal, obj.Ordinal);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            return stringWriter.ToString();
        }

        public StatusAuditor(Status obj)
        {
            this.Object = obj;
        }
    }
}
