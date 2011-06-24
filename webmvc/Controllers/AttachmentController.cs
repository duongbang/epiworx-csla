using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class AttachmentController : Controller
    {
        public ActionResult Details(int id)
        {
            var attachment = AttachmentRepository.AttachmentFetch(id);

            var ms = new System.IO.MemoryStream(attachment.FileData, 0, attachment.FileData.Length);

            return new FileStreamResult(ms, attachment.FileType);
        }

        public ActionResult Create(int sourceId, int sourceTypeId)
        {
            var model = new AttachmentFormModel();
            var attachment = AttachmentRepository.AttachmentNew(sourceId, (SourceType)sourceTypeId);

            model.Title = "Attachment Create";
            model.Attachment = attachment;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int sourceId, int sourceTypeId, FormCollection collection)
        {
            var model = new AttachmentFormModel();
            var attachment = AttachmentRepository.AttachmentNew(sourceId, (SourceType)sourceTypeId);

            this.Map(collection, attachment);

            attachment = AttachmentRepository.AttachmentSave(attachment);

            if (attachment.IsValid)
            {
                return this.RedirectToAction("Details", attachment.SourceTypeName, new { id = attachment.SourceId });
            }

            model.Title = "Attachment Create";
            model.Attachment = attachment;

            ModelHelper.MapBrokenRules(this.ModelState, attachment);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new AttachmentFormModel();
            var attachment = AttachmentRepository.AttachmentFetch(id);

            model.Title = "Attachment Edit";
            model.Attachment = attachment;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new AttachmentFormModel();
            var attachment = AttachmentRepository.AttachmentFetch(id);

            this.Map(collection, attachment);

            attachment = AttachmentRepository.AttachmentSave(attachment);

            if (attachment.IsValid)
            {
                return this.RedirectToAction("Details", attachment.SourceTypeName, new { id = attachment.SourceId });
            }

            model.Title = "Attachment Edit";
            model.Attachment = attachment;

            ModelHelper.MapBrokenRules(this.ModelState, attachment);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var attachment = AttachmentRepository.AttachmentFetch(id);

            model.Title = "Attachment Delete";
            model.Id = attachment.AttachmentId;
            model.Name = "Attachment";
            model.Description = attachment.Name;
            model.ControllerName = "Attachment";
            model.BackUrl = Url.Action("Details", attachment.SourceTypeName, new { id = attachment.SourceId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var attachment = AttachmentRepository.AttachmentFetch(id);

            AttachmentRepository.AttachmentDelete(id);

            return this.RedirectToAction("Details", attachment.SourceTypeName, new { id = attachment.SourceId });
        }

        private void Map(FormCollection source, Attachment destination)
        {
            destination.Name = source["Name"];

            var file = this.Request.Files["FileData"];

            if (file != null)
            {
                var fileData = new byte[file.ContentLength];

                file.InputStream.Read(fileData, 0, file.ContentLength);

                destination.FileData = fileData;

                if (string.IsNullOrEmpty(destination.Name))
                {
                    destination.Name = Path.GetFileName(file.FileName);
                }

                destination.FileType = file.ContentType;
            }
        }
    }
}
