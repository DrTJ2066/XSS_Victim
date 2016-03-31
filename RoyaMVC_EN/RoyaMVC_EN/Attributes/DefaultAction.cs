using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace RoyaMVC.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class DefaultAction : ActionFilterAttribute 
    {
        public string ActionName { get; set; }
        //public string AnonymouseActionName { get; set; }
        //List<string> rolesList = new List<string>();
        //public bool IsAnonymous { get; set; }
        
        public DefaultAction(string actionName /*, string anonymouseActionName, string appliedRoles*/) {
            this.ActionName = actionName;
            //this.AnonymouseActionName = anonymouseActionName;
            //this.IsAnonymous = string.IsNullOrWhiteSpace(appliedRoles);
            
            //if (this.IsAnonymous == false)
            //    this.rolesList = appliedRoles.Replace(" ", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            //var isUserInDefinedRoles = IsInDefinedRoles(filterContext);
            if (string.IsNullOrWhiteSpace(filterContext.ActionDescriptor.ActionName)) {
                filterContext.HttpContext.Response.Redirect("/" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + this.ActionName);
            }

            //filterContext.ActionDescriptor.ActionName
        }

        //public bool IsInDefinedRoles(ActionExecutingContext filterContext) {
        //    if (this.rolesList.Count > 0) {
        //        foreach (var item in this.rolesList)
        //            if (filterContext.HttpContext.User.IsInRole(item))
        //                return true;
        //    }

        //    return false;
        //}
    }
}
