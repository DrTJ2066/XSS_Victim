using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Objects
{
    public class MVCObjectBaseViewModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string URLControllerName { get; set; }
        public string URLActionName { get; set; }
        public object URLRouteValues { get; set; }

        public MVCObjectBaseViewModel() {
            this.URLControllerName = "Home";
            this.URLActionName = "Index";
            this.URLRouteValues = null;
        }

        public MVCObjectBaseViewModel(string id, string title, string controllerName, string actionName, object routeValues) {
            this.ID = id;
            this.Title = title;
            this.URLControllerName = controllerName;
            this.URLActionName = actionName;
            this.URLRouteValues = routeValues;
        }
    }
}
