using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Objects
{
    public class OptionItemViewModel : MVCObjectBaseViewModel
    {
        public string ImageURLControllerName { get; set; }
        public string ImageURLActionName { get; set; }
        public object ImageURLRouteValues { get; set; }
        public string ImageAlternativeText { get; set; }

        public OptionItemViewModel()
            : base() {
            this.ImageURLControllerName = "Resources";
            this.ImageURLActionName = "GetImageFromResources";
        }

        public OptionItemViewModel(string id, string title)
            : base() {

            this.ID = id;
            this.Title = title;

            this.ImageURLControllerName = "Resources";
            this.ImageURLActionName = "GetImageFromResources";
            this.ImageAlternativeText = title;
            this.ImageURLRouteValues = null;
        }

        public OptionItemViewModel(string id, string title, string controllerName)
            : base(id, title, controllerName, "Index", null) {

            this.ImageURLControllerName = "Resources";
            this.ImageURLActionName = "GetImageFromResources";
            this.ImageAlternativeText = title;
        }

        public OptionItemViewModel(string id, string title, string controllerName, string actionName)
            : base(id, title, controllerName, actionName, null) {

            this.ImageURLControllerName = "Resources";
            this.ImageURLActionName = "GetImageFromResources";
            this.ImageAlternativeText = title;
        }

        public OptionItemViewModel(string id, string title, string controllerName, string actionName, object routeValues)
            : base(id, title, controllerName, actionName, routeValues) {

            this.ImageURLControllerName = "Resources";
            this.ImageURLActionName = "GetImageFromResources";
            this.ImageAlternativeText = title;
        }

    }
}
