using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Helpers;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class NoteController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Create(int sourceId, int sourceTypeId)
        {
            var model = new NoteFormModel();
            var note = NoteRepository.NoteNew(sourceId, (SourceType)sourceTypeId);

            model.Title = "Note Create";
            model.Note = note;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(int sourceId, int sourceTypeId, FormCollection collection)
        {
            var model = new NoteFormModel();
            var note = NoteRepository.NoteNew(sourceId, (SourceType)sourceTypeId);

            this.Map(collection, note);

            note = NoteRepository.NoteSave(note);

            if (note.IsValid)
            {
                return this.RedirectToAction("Details", note.SourceTypeName, new { id = note.SourceId });
            }

            model.Title = "Note Create";
            model.Note = note;

            ModelHelper.MapBrokenRules(this.ModelState, note);

            return this.View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new NoteFormModel();
            var note = NoteRepository.NoteFetch(id);

            model.Title = "Note Edit";
            model.Note = note;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = new NoteFormModel();
            var note = NoteRepository.NoteFetch(id);

            this.Map(collection, note);

            note = NoteRepository.NoteSave(note);

            if (note.IsValid)
            {
                return this.RedirectToAction("Details", note.SourceTypeName, new { id = note.SourceId });
            }

            model.Title = "Note Edit";
            model.Note = note;

            ModelHelper.MapBrokenRules(this.ModelState, note);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = new DeleteModel();
            var note = NoteRepository.NoteFetch(id);

            model.Title = "Note Delete";
            model.Id = note.NoteId;
            model.Name = "Note";
            model.Description = note.Body;
            model.ControllerName = "Note";
            model.BackUrl = Url.Action("Details", note.SourceTypeName, new { id = note.SourceId });

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var note = NoteRepository.NoteFetch(id);

            NoteRepository.NoteDelete(id);

            return this.RedirectToAction("Details", note.SourceTypeName, new { id = note.SourceId });
        }

        private void Map(FormCollection source, Note destination)
        {
            destination.Body = source["Body"];
        }
    }
}
