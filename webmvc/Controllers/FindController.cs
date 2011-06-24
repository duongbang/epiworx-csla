using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    public class FindController : Controller
    {
        public ActionResult Index()
        {
            var model = new FindIndexModel();
            var filterFields = new List<FilterField>();

            filterFields.Add(
                new FilterField
                    {
                        Name = "projectName",
                        Description = "The name of the project",
                        Categories = new[] { "Hour", "Project", "Story" }
                    });

            filterFields.Add(
               new FilterField
               {
                   Name = "userName",
                   Description = "The name of the user",
                   Categories = new[] { "Hour", "Project", "Story", "User" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "statusName",
                   Description = "The name of the project status",
                   Categories = new[] { "Hour", "Story" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "sprintName",
                   Description = "The name of the project sprint",
                   Categories = new[] { "Hour", "Story" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "isArchived",
                   Description = "The archive state",
                   Categories = new[] { "Hour", "Project", "Story", "User" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "Description",
                   Description = "The description",
                   Categories = new[] { "Project", "Story" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "createdDateFrom",
                   Description = "The start date of the created on date range",
                   Categories = new[] { "Hour", "Project", "Story", "User" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "createdDateTo",
                   Description = "The end date of the created on date range",
                   Categories = new[] { "Hour", "Project", "Story", "User" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "modifiedDateFrom",
                   Description = "The start date of the modified on date range",
                   Categories = new[] { "Hour", "Project", "Story", "User" }
               });

            filterFields.Add(
               new FilterField
               {
                   Name = "modifiedDateTo",
                   Description = "The end date of the modified on date range",
                   Categories = new[] { "Hour", "Project", "Story", "User" }
               });

            model.FilterFields = filterFields;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var controllerName = collection["FindCategory"];
            var queryString = collection["FindText"];

            return this.Redirect(Url.Action("Index", controllerName) + "?" + queryString);
        }
    }
}
