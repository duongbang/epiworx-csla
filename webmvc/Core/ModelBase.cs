﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epiworx.Business;
using Epiworx.WebMvc.Models;

namespace Epiworx.WebMvc
{
    public enum MessageType
    {
        None,
        Success,
        Fail
    }

    public class ModelBase
    {
        public string Title { get; set; }
        public ActionItemCollection Actions { get; set; }
        public int OrganizationId { get; set; }
        public IEnumerable<OrganizationInfo> Organizations { get; set; }

        public ModelBase()
        {
            this.Actions = new ActionItemCollection();
            this.Organizations = OrganizationRepository.OrganizationFetchInfoList();

            try
            {
                this.OrganizationId = int.Parse(HttpContext.Current.Request.Cookies["OrganizationId"].Value);
            }
            catch
            {
                if (this.Organizations.Count() != 0)
                {
                    this.OrganizationId = this.Organizations.First().OrganizationId;
                }
                else
                {
                    this.OrganizationId = 0;
                }
            }
        }
    }
}