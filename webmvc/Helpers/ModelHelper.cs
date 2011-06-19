using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Helpers
{
    public class ModelHelper
    {
        public static void MapBrokenRules(ModelStateDictionary modelState, Csla.Core.BusinessBase businessObject)
        {
            foreach (var brokenRule in businessObject.BrokenRulesCollection)
            {
                modelState.AddModelError(brokenRule.Property, brokenRule.Description);
            }
        }
    }
}