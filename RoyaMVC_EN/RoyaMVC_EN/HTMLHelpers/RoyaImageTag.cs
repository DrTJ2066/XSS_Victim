using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public enum ImageLocatingMethods { ByController, ByPath }

    public class RoyaImageTag : RoyaTagBase
    {
        public static RoyaImageTag EmptyImage = new RoyaImageTag("", "", "", null, TagRenderMode.Normal);

        //public string URLControllerName { get; set; }
        //public string URLActionName { get; set; }
        //public object URLRouteValues { get; set; }
        public Models.RouteModel ImageURL { get; set; }

        public string AlternativeText { get; set; }
        public HtmlHelper htmlHelper { get; set; }
        public ImageLocatingMethods LocatingMethod { get; set; }
        public string ResourcePath { get; set; }



        public RoyaImageTag(string name, string src, string alt, object htmlAttributes, TagRenderMode tagRenderMode)
            : base(name, name, htmlAttributes, null) {

            this.ResourcePath = src;
            this.AlternativeText = alt;
            this.HtmlAttributes = htmlAttributes;

            this.LocatingMethod = ImageLocatingMethods.ByPath;
            this.TagRenderMode = tagRenderMode;
        }

        public RoyaImageTag(HtmlHelper helper, string name, Models.RouteModel imageURL, string alternativeText, object htmlAttributes, object events, TagRenderMode tagRenderMode)
            : base(name, name, htmlAttributes, null) {

            //this.URLActionName = actionName;
            //this.URLControllerName = controllerName;
            //this.URLRouteValues = actionRouteValues;
            this.ImageURL = imageURL;
            this.AlternativeText = alternativeText;
            this.HtmlAttributes = htmlAttributes;
            this.Events = events;

            this.htmlHelper = helper;

            this.LocatingMethod = ImageLocatingMethods.ByController;
            this.TagRenderMode = tagRenderMode;
        }

        public override MvcHtmlString ToHtmlTag() {
            TagBuilder imageTag = new TagBuilder("img");

            if (this.LocatingMethod == ImageLocatingMethods.ByController) {
                //<img id="ImageTagName" name="ImageTagName" 
                //     src="@Url.Action(@Model.URLActionName, @Model.URLControllerName, @Model.URLRouteValues)" alt="@Model.ImageAlternativeText" />

                var urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;
                imageTag.Attributes.Add("src", this.ImageURL.GetActionURL(ref urlHelper)); // urlHelper.Action(this.ImageURL.ActionName, this.ImageURL.ControllerName, this.ImageURL.RouteValues));
            }
            else {
                //<img id="ImageTagName" name="ImageTagName" src="/images/image1.jpg" alt="alternative text" />
                imageTag.Attributes.Add("src", this.ResourcePath);
            }

            imageTag.Attributes.Add("id", this.ID);
            imageTag.Attributes.Add("name", this.ID);
            imageTag.Attributes.Add("alt", this.AlternativeText);
            imageTag.MergeAttributes(new RouteValueDictionary(this.HtmlAttributes));
            imageTag.MergeAttributes(new RouteValueDictionary(this.Events));

            return new MvcHtmlString(imageTag.ToString(this.TagRenderMode));
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }


        public static MvcHtmlString RoyaImage(HtmlHelper html, string name, Models.RouteModel imageURL, string imageAlternativeText, object htmlAttributes, object events) {
            var tmp = new RoyaImageTag(html, name, imageURL, imageAlternativeText, htmlAttributes, events, TagRenderMode.Normal);
            return tmp.ToHtmlTag();
        }
    }
}
