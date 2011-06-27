using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public string ReturnUrl { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public ActionItemCollection Actions { get; set; }

        public ModelBase()
        {
            this.MessageType = MessageType.None;
            this.Actions = new ActionItemCollection();
        }
    }
}