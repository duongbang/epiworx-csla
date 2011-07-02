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
    public class ProjectAuditor : IAuditor<Project>
    {
        public Project Object { get; internal set; }

        public string Audit(Project obj)
        {
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Changes");

            xmlWriter = AuditorHelper.Audit(xmlWriter, "Description", this.Object.Description, obj.Description);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsActive", this.Object.IsActive, obj.IsActive);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "IsArchived", this.Object.IsArchived, obj.IsArchived);
            xmlWriter = AuditorHelper.Audit(xmlWriter, "Name", this.Object.Name, obj.Name);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            return stringWriter.ToString();
        }

        public ProjectAuditor(Project obj)
        {
            this.Object = obj;
        }
    }
}
