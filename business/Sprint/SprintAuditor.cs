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
    public class SprintAuditor : IAuditor<Sprint>
    {
        public Sprint Object { get; internal set; }

        public string Audit(Sprint obj)
        {
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Changes");

            xmlWriter = AuditorHelper.Audit(xmlWriter, "CompletedDate", this.Object.CompletedDate, obj.CompletedDate);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Description", this.Object.Description, obj.Description);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Duration", this.Object.Duration, obj.Duration);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "EstimatedDuration", this.Object.EstimatedDuration, obj.EstimatedDuration);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "EstimatedCompletedDate", this.Object.EstimatedCompletedDate, obj.EstimatedCompletedDate);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsActive", this.Object.IsActive, obj.IsActive);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsArchived", this.Object.IsArchived, obj.IsArchived);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsCompleted", this.Object.IsCompleted, obj.IsCompleted);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Name", this.Object.Name, obj.Name);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            return stringWriter.ToString();
        }

        public SprintAuditor(Sprint obj)
        {
            this.Object = obj;
        }
    }
}
