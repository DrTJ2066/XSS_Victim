using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaTextBoxTag : RoyaTagBase
    {
        public int MaximumLength{get;set;}
        public string Value { get; set; }

        public RoyaTextBoxTag(string name, string value, int maxLength, object htmlAttributes, object events)
            : base(name, name, htmlAttributes, events) {

            this.MaximumLength = maxLength;
            this.Value = value;
        }

        public override MvcHtmlString ToHtmlTag() {
            var resTag = new TagBuilder("input");
            resTag.Attributes.Add("type", "text");
            resTag.Attributes.Add("id", this.ID);
            resTag.Attributes.Add("name", this.Name);
            resTag.Attributes.Add("value", this.Value);

            if (this.MaximumLength > 0)
                resTag.Attributes.Add("maxlength", this.MaximumLength.ToString());

            resTag.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes));
            resTag.MergeAttributes(new RouteValueDictionary(this.Events));
            
            return new MvcHtmlString(resTag.ToString(System.Web.Mvc.TagRenderMode.SelfClosing));
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }

        public static MvcHtmlString RoyaTextBox(string name, string value, int maxLength, string htmlAttributes) {
            var tagYearInput = new TagBuilder(name + "Year");
            tagYearInput.Attributes.Add("type", "text");
            tagYearInput.Attributes.Add("id", name + "Year");
            tagYearInput.Attributes.Add("value", value);

            if (maxLength > 0)
                tagYearInput.Attributes.Add("maxlength", maxLength.ToString());

            tagYearInput.MergeAttribute("style", "width: 50px; text-align: center;");

            return new MvcHtmlString(tagYearInput.ToString(TagRenderMode.SelfClosing));
        }
    }
}
