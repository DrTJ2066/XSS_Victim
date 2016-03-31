using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public abstract class RoyaTagBase
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string InnerHtml { get; set; }
        public System.Web.Mvc.TagRenderMode TagRenderMode { get; set; }
        public object HtmlAttributes { get; set; }
        public object Events { get; set; }

        public RoyaTagBase(string id, string name) : this(id, name, "", null, null, TagRenderMode.SelfClosing) { }

        public RoyaTagBase(string id, string name, object htmlAttributes, object events) : this(id, name, "", htmlAttributes, events, TagRenderMode.SelfClosing) { }

        public RoyaTagBase(string id, string name, string innerHtml, object htmlAttributes, object events, TagRenderMode tagRenderMode) {
            this.ID = id;
            this.Name = name;
            this.InnerHtml = innerHtml;
            this.HtmlAttributes = htmlAttributes;
            this.Events = events;
            this.TagRenderMode = tagRenderMode;
        }

        public abstract MvcHtmlString ToHtmlTag();

        public abstract string ToHtmlString();
    }
}
