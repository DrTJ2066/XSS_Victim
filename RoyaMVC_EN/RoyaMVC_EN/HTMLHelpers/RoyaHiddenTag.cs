using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace RoyaMVC_EN.HTMLHelpers
{
    class RoyaHiddenTag : RoyaTagBase
    {
        public string Value { get; set; }

        public RoyaHiddenTag(string name, string value) : base(name, name) { this.Value = value; }

        public override MvcHtmlString ToHtmlTag() {
            var resInputTag = new TagBuilder("input");
            resInputTag.Attributes.Add("type", "hidden");
            resInputTag.Attributes.Add("id", this.ID);
            resInputTag.Attributes.Add("name", this.Name);
            resInputTag.Attributes.Add("value", this.Value);

            return new MvcHtmlString(resInputTag.ToString(System.Web.Mvc.TagRenderMode.SelfClosing));
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }
    }
}
