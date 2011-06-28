using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business.Repositories;
using Epiworx.WebMvc.Core;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class FindController : Controller
    {
        public ActionResult Index(string global, string scope, string terms)
        {
            var model = new FindIndexModel();

            model.FindText = terms;

            if (!string.IsNullOrEmpty(terms))
            {
                var findResults = FindRepository.Find(model.FindText)
                    .OrderBy(row => row.Type)
                    .ThenByDescending(row => row.CreatedDate)
                    .AsEnumerable();

                switch (scope)
                {
                    case "hours":
                        findResults = findResults.Where(row => row.Type == "Hour").AsEnumerable();
                        break;
                    case "projects":
                        findResults = findResults.Where(row => row.Type == "Project").AsEnumerable();
                        break;
                    case "stories":
                        findResults = findResults.Where(row => row.Type == "Story").AsEnumerable();
                        break;
                    case "users":
                        findResults = findResults.Where(row => row.Type == "User").AsEnumerable();
                        break;
                }

                model.FindResults = findResults;
                model.ShowScope = true;
            }

            return View(model);
        }
    }
}
