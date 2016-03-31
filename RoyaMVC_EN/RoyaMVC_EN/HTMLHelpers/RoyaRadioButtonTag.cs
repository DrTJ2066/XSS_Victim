using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaRadioButtonTag : RoyaTagBase
    {
        public string GroupName{get;set;}
        public string RadioButtonTitle{get;set;}
        public string Value{get;set;}

        public RoyaRadioButtonTag(string name, string groupName, string radioButtonTitle, string value, object htmlAttributes, object events)
            : base(name, name, htmlAttributes, events) {

            this.GroupName = groupName;
            this.RadioButtonTitle = radioButtonTitle;
            this.Value = value;
        }

        public override MvcHtmlString ToHtmlTag() {
            //<input type="radio" id="c1" name="cc" />
            //<label for="c1"><span></span>Radio Button 1</label>

            TagBuilder inputBuilder = new TagBuilder("input");
            inputBuilder.Attributes.Add("type", "radio");
            inputBuilder.Attributes.Add("id", this.ID);
            inputBuilder.Attributes.Add("name", this.GroupName);
            inputBuilder.Attributes.Add("value", this.Value);
            inputBuilder.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes));
            inputBuilder.MergeAttributes(new RouteValueDictionary(this.Events));

            TagBuilder labelBuilder = new TagBuilder("label");
            labelBuilder.Attributes.Add("for", this.Name);
            labelBuilder.Attributes.Add("id", this.Name + "Label");
            labelBuilder.Attributes.Add("name", this.Name + "Label");
            labelBuilder.Attributes.Add("style", "cursor:pointer;");
            labelBuilder.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes), true);

            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.Attributes.Add("id", this.Name + "Span");
            spanBuilder.Attributes.Add("name", this.Name + "Span");
            //spanBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            labelBuilder.InnerHtml = spanBuilder.ToString(TagRenderMode.Normal) + this.RadioButtonTitle;
            var res = inputBuilder.ToString(TagRenderMode.SelfClosing) + labelBuilder.ToString(TagRenderMode.Normal);
            return new MvcHtmlString(res);
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }

        public static MvcHtmlString RoyaRadioButton(string name, string groupName, string radioButtonTitle, string value, object htmlAttributes, object events) {
            return RoyaRadioButton(name, groupName, radioButtonTitle, value, htmlAttributes, null, null, events);
        }

        public static MvcHtmlString RoyaRadioButton(string name, string groupName, string radioButtonTitle, string value, object htmlAttributesInput, object htmlAttributesLabel, object htmlAttributesSpan, object events) {
            //<input type="radio" id="c1" name="cc" />
            //<label for="c1"><span></span>Radio Button 1</label>

            var htmlAttrib = new RouteValueDictionary(htmlAttributesInput);
            if (!htmlAttrib.Keys.Contains("Class")) {
                htmlAttrib.Add("Class", "RoyaRadioButton");
            }

            TagBuilder inputBuilder = new TagBuilder("input");
            inputBuilder.Attributes.Add("type", "radio");
            inputBuilder.Attributes.Add("id", name);
            inputBuilder.Attributes.Add("name", groupName);
            inputBuilder.Attributes.Add("value", value);
            inputBuilder.MergeAttributes(htmlAttrib);
            inputBuilder.MergeAttributes(new RouteValueDictionary(events));

            TagBuilder labelBuilder = new TagBuilder("label");
            labelBuilder.Attributes.Add("for", name);
            labelBuilder.Attributes.Add("id", name + "Label");
            labelBuilder.Attributes.Add("name", name + "Label");
            labelBuilder.Attributes.Add("style", "cursor:pointer;");
            labelBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributesLabel), true);

            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.Attributes.Add("id", name + "Span");
            spanBuilder.Attributes.Add("name", name + "Span");
            spanBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributesSpan));

            labelBuilder.InnerHtml = spanBuilder.ToString(TagRenderMode.Normal) + radioButtonTitle;
            var res = inputBuilder.ToString(TagRenderMode.SelfClosing) + labelBuilder.ToString(TagRenderMode.Normal);
            return new MvcHtmlString(res);
        }

    }
}
