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
    public class StoryAuditor : IAuditor<Story>
    {
        public Story Object { get; internal set; }

        public string Audit(Story obj)
        {
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Changes");

            xmlWriter = AuditorHelper.Audit(xmlWriter, "AssignedToName", this.Object.AssignedToName, obj.AssignedToName);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "AssignedDate", this.Object.AssignedDate, obj.AssignedDate);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "CompletedDate", this.Object.CompletedDate, obj.CompletedDate);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Description", this.Object.Description, obj.Description);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Duration", this.Object.Duration, obj.Duration);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "EstimatedCompletedDate", this.Object.EstimatedCompletedDate, obj.EstimatedCompletedDate);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "EstimatedDuration", this.Object.EstimatedDuration, obj.EstimatedDuration);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsArchived", this.Object.IsArchived, obj.IsArchived);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsCompleted", this.Object.IsCompleted, obj.IsCompleted);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "SprintName", this.Object.SprintName, obj.SprintName);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "StartDate", this.Object.StartDate, obj.StartDate);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "StatusName", this.Object.StatusName, obj.StatusName);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            return stringWriter.ToString();
        }

        public StoryAuditor(Story obj)
        {
            this.Object = obj;
        }
    }
}
