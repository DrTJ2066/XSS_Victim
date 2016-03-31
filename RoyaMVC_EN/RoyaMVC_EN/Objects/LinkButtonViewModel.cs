using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Objects
{
    public class LinkButtonViewModel : MVCObjectBaseViewModel
    {
        public LinkButtonViewModel() : base() { }
        public LinkButtonViewModel(string id, string title, string controllerName, string actionName, object routeValues) : base(id, title, controllerName, actionName, routeValues) { }
        public LinkButtonViewModel(string title, string controllerName, string actionName) : base("", title, controllerName, actionName, null) { }
    }
}
