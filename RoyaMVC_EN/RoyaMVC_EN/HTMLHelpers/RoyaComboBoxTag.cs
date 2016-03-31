using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaComboBoxTag : RoyaTagBase
    {
        public int SelectedIndex { get; set; }
        public List<RoyaComboBoxItemTag> Options { get; set; }

        public RoyaComboBoxTag(string name, List<RoyaComboBoxItemTag> options, object htmlAttributes, object events)
            : base(name, name, htmlAttributes, events) {

            this.Options = options;
            this.TagRenderMode = System.Web.Mvc.TagRenderMode.Normal;
        }

        public override MvcHtmlString ToHtmlTag() {
            var res = "";

            var resTag = new TagBuilder("select");
            resTag.Attributes.Add("name", this.Name);
            resTag.Attributes.Add("id", this.ID);
            resTag.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes));

            var optionTagsString = RoyaComboBoxItemTag.ToTagsString(this.Options);

            res = resTag.ToString(TagRenderMode.StartTag) +
                  optionTagsString +
                  resTag.ToString(TagRenderMode.EndTag);

            return new MvcHtmlString(res);
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }
    }

    public class RoyaComboBoxItemTag
    {
        public string Value { get; set; }
        public string InnerText { get; set; }
        public bool IsSelected { get; set; }

        public RoyaComboBoxItemTag(string text, string value) {
            this.InnerText = text;
            this.Value = value;
            this.IsSelected = false;
        }

        public RoyaComboBoxItemTag(string text, string value, bool isSelected) {
            this.InnerText = text;
            this.Value = value;
            this.IsSelected = isSelected;
        }

        public override string ToString() {
            if (this.IsSelected)
                return string.Format("<option value='{0}' selected='selected'>{1}</option>", this.Value, this.InnerText);
            else
                return string.Format("<option value='{0}'>{1}</option>", this.Value, this.InnerText);
        }

        public static string ToTagsString(List<RoyaComboBoxItemTag> items) {
            var resList =new List<string>();

            foreach (var item in items) {
                resList.Add(item.ToString());
            }

            var res = string.Join("\n", resList);
            return res.ToString();
        }
    }
}
