using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RoyaMVC_EN.Models
{
    public class RouteModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public object RouteValues { get; set; }
        public bool IsSimpleURL { get; set; }

        //public static RouteModel ImageResourceFromResourceManager = new RouteModel("ResourceManager", "GetImageResource", 

        /// <summary>
        /// Redirects to the Index action of the Controller.
        /// </summary>
        /// <param name="controller"></param>
        public RouteModel(string controller) : this(controller, "Index", null, false) { }

        public RouteModel(string controller, string action) : this(controller, action, null, false) { }

        public RouteModel(string controller, object routeValues) : this(controller, "Index", routeValues, false) { }

        public RouteModel(string controller, string action, object routeValues) : this(controller, action, routeValues, false) { }

        public RouteModel(string controller, string action, object routeValues, bool isSimpleURL) {
            this.ControllerName = controller;
            this.ActionName = action;
            this.RouteValues = routeValues;
            this.IsSimpleURL = isSimpleURL;
        }



        /// <summary>
        /// Get Image Resource from ResourceManager
        /// </summary>
        /// <param name="routeValues">GetImageResource parameters</param>
        /// <param name="resourceType">Used to point to the GetImageResource. Set it as RoyaMVC_EN.HTMLHelpers.RoyaImageTag.Empty</param>
        public RouteModel(object routeValues, RoyaMVC_EN.HTMLHelpers.RoyaImageTag resourceType) : this("ResourceManager", "GetImageResource", routeValues, false) { }

        /// <summary>
        /// Get Image Resource from ImageResourceManager
        /// </summary>
        /// <param name="routeValues">GetImageResource parameters</param>
        /// <param name="resourceType">Used to point to the GetFileResource</param>
        public RouteModel(object routeValues, System.IO.FileInfo resourceType) : this("ResourceManager", "GetFileResource", routeValues, false) { }


        public RouteModel(string url, bool isSimpleURL) : this(url, "", null, true) { }

        public RouteModel(string resourceID, int size) : this("/Content/Images/" + size.ToString() + "/" + resourceID, "", null, true) { }

        public string GetActionURL(ref System.Web.Mvc.UrlHelper urlHelper) {
            if (this.IsSimpleURL)
                return this.ControllerName;
            else
                return urlHelper.Action(this.ActionName, this.ControllerName, this.RouteValues);
        }
    }
}
