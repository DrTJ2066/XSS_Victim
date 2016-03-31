using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public enum LinkTarget { _blank, _parent, _self, _top }

    public class RoyaHyperlinkTag: RoyaTagBase
    {
        public MvcHtmlString Content { get; set; }
        public string LinkURL { get; set; }
        public LinkTarget Target { get; set; }
        public HtmlHelper htmlHelper { get; set; }

        public RoyaHyperlinkTag(HtmlHelper htmlHelper, string id, string name, MvcHtmlString Content, string LinkURL, LinkTarget TargetObject, object HtmlAttributes, object Events, TagRenderMode tagRenderMode)
            : base(id, name, Content.ToHtmlString(), HtmlAttributes, Events, tagRenderMode) {

            this.Content = Content;
            this.LinkURL = LinkURL;
            this.Target = TargetObject;
            this.htmlHelper = htmlHelper;
        }

        public override MvcHtmlString ToHtmlTag() {
            TagBuilder linkTag = new TagBuilder("a");

            linkTag.Attributes.Add("href", this.LinkURL);
            linkTag.Attributes.Add("id", this.ID);
            linkTag.Attributes.Add("name", this.ID);
            linkTag.Attributes.Add("target", this.Target.ToString());
            linkTag.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes));
            linkTag.MergeAttributes(new RouteValueDictionary(this.Events));

            var res = linkTag.ToString(TagRenderMode.StartTag) + Content.ToHtmlString() + linkTag.ToString(TagRenderMode.SelfClosing);
            return new MvcHtmlString(res);
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }


        public static MvcHtmlString RoyaHyperlink(HtmlHelper html, string name,  MvcHtmlString Content, string LinkURL, LinkTarget TargetObject, object HtmlAttributes, object Events) {
            var tmp = new RoyaHyperlinkTag(html, name, name, Content, LinkURL, TargetObject, HtmlAttributes, Events, TagRenderMode.Normal);
            return tmp.ToHtmlTag();
        }
    }
}
