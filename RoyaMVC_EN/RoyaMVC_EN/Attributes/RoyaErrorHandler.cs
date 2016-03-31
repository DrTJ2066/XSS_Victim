using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace RoyaMVC_EN.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class RoyaErrorHandlerAttribute : HandleErrorAttribute 
    {
        public override void OnException(ExceptionContext filterContext){
            var resMessages = new List<RoyaMVC_EN.Models.AppMessage>();

            if (filterContext.Controller.ViewBag.Messages != null) {
                resMessages.AddRange(filterContext.Controller.ViewBag.Messages as List<RoyaMVC_EN.Models.AppMessage>);
            }

            resMessages.AddRange(RoyaMVC_EN.Models.AppMessage.Add(filterContext.Exception.Message, RoyaMVC_EN.Models.AppMessageTypes.ErrorMessage));
            filterContext.Controller.ViewBag.Messages = resMessages;
            //base.OnException(filterContext);
        }
    }
}
