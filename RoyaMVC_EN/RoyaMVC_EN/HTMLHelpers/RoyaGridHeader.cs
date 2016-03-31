using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaGridHeader : RoyaTagBase
    {
        public string GridHeaderTitle { get; set; }
        public object GridSummaryText { get; set; }
        public object FilterBoxHtmlAttributes { get; set; }
        public object SummaryBoxHtmlAttributes { get; set; }

        public RoyaGridHeader(string name, string GridHeaderTitle, object GridSummaryText) :
            this(name, GridHeaderTitle, GridSummaryText, null, null, new { @class = "GridFilterInput" }, new { @class = "GridSummaryLabel" }) { }

        public RoyaGridHeader(string name, string GridHeaderTitle, object GridSummaryText, object htmlAttributes, object events, object filterBoxHtmlAttributes, object summaryBoxHtmlAttributes)
            : base(name, name, htmlAttributes, events) {

            this.GridHeaderTitle = GridHeaderTitle;
            this.GridSummaryText = GridSummaryText;
            this.FilterBoxHtmlAttributes = filterBoxHtmlAttributes;
            this.SummaryBoxHtmlAttributes = summaryBoxHtmlAttributes;
        }
        
        public override MvcHtmlString ToHtmlTag() {
            var inputTag = new RoyaTextBoxTag(this.Name + "FilterBox", "", 0, this.FilterBoxHtmlAttributes, null);
            var summaryLabel = new RoyaLabelTag(this.Name + "SummaryBox", (this.GridSummaryText ?? "---").ToString(), this.SummaryBoxHtmlAttributes, null);
            var valueLabel = new RoyaLabelTag(this.Name + "Value", this.GridHeaderTitle, new { @class = "GridHeaderLabel" }, null);

            
            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.Attributes.Add("id", this.Name + "Span");
            spanBuilder.Attributes.Add("name", this.Name + "Span");
            spanBuilder.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes), true);
            spanBuilder.MergeAttributes(new RouteValueDictionary(this.Events), true);

            spanBuilder.InnerHtml = string.Format("{0}{1}{2}", valueLabel.ToHtmlTag(), inputTag.ToHtmlTag(), summaryLabel.ToHtmlTag());

            return new MvcHtmlString(spanBuilder.ToString(TagRenderMode.Normal));
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }
    }
}
