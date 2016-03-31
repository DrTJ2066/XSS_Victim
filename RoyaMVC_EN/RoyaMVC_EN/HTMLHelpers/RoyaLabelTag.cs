using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaLabelTag: RoyaTagBase
    {
        public string Value { get; set; }

        public RoyaLabelTag(string name, string value, object htmlAttributes, object events)
            : base(name, name, htmlAttributes, events) {
            this.TagRenderMode = System.Web.Mvc.TagRenderMode.Normal;
            this.Value = value;
        }

        public RoyaLabelTag(string name, string value) : this(name, value, null, null) { }


        public override System.Web.Mvc.MvcHtmlString ToHtmlTag() {
            var labelBuilder = new TagBuilder("label");
            labelBuilder.Attributes.Add("id", this.Name + "Label");
            labelBuilder.Attributes.Add("name", this.Name + "Label");
            labelBuilder.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes), true);
            labelBuilder.MergeAttributes(new RouteValueDictionary(this.Events), true);

            labelBuilder.InnerHtml = this.Value;

            return new MvcHtmlString(labelBuilder.ToString(this.TagRenderMode));
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }

    }
}
