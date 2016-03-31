using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaOptionItemTag : RoyaTagBase
    {
        public string Title { get; set; }

        public Models.RouteModel LinkURL { get; set; }
        public Models.RouteModel ImageURL { get; set; }
        public string ImageAlternativeText { get; set; }
        public HtmlHelper htmlHelper { get; set; }
        public OptionAppearance DefaultAppearance { get; set; }
        public string Details { get; set; }
        public Models.RoyaOptionNotification NotificationData { get; set; }
        public Action<RoyaOptionItemTag> UserChangesFunction;

        public TagBuilder wrapperDiv;
        public TagBuilder wrapperLink;
        public TagBuilder innerDiv;
        public TagBuilder notificationBox;
        public TagBuilder innerImage;
        public TagBuilder innerText;

        public RoyaOptionItemTag(HtmlHelper html, string name, string title, Models.RouteModel linkURL, Models.RouteModel imageURL, string imageAlternativeText, object htmlAttributes, object events, OptionAppearance defaultAppearance, string details, Action<RoyaOptionItemTag> userChanges, Models.RoyaOptionNotification notificationData = null)
            : base(name, name, htmlAttributes, events) {

            this.Title = title;
            this.LinkURL = linkURL;
            this.ImageURL = imageURL;
            this.ImageAlternativeText = imageAlternativeText;
            this.DefaultAppearance = defaultAppearance;
            this.Details = details;
            this.NotificationData = notificationData;
            this.UserChangesFunction = userChanges;

            this.htmlHelper = html;
        }

        public override MvcHtmlString ToHtmlTag() {
            var urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;

            //<div class="OptionItem OptionItem_Blue" id="@Model.ID">
            //    <a id="optionLink" href="@Url.Action(@Model.URLActionName, @Model.URLControllerName, @Model.URLRouteValues)" >
            //        <div style="width:100%; height:100%;">
            //            <img id="optionImage" src="@Url.Action(@Model.ImageURLActionName, @Model.ImageURLControllerName, @Model.ImageURLRouteValues)" alt="@Model.ImageAlternativeText" style="height: 100%;"  /><br />
            //            <div id="optionText">@Model.Title</div>   OR  <span id="optionText">@Model.Title</span>
            //        </div>
            //    </a>
            //</div>

            var defaultAppearanceClass = (this.DefaultAppearance == OptionAppearance.OptionItem) ? "OptionItem OptionItem_Blue" : "ThumbnailItem";

            var htmlAttrib = new RouteValueDictionary(this.HtmlAttributes);            //new { @class = "OptionItem OptionItem_Blue" }
            //if (htmlAttrib.Keys.Contains("class")) {
            if ((htmlAttrib.Count(w => w.Value.ToString().Contains("OptionItem")) == 0) &&
                (htmlAttrib.Count(w => w.Value.ToString().Contains("ThumbnailItem")) == 0)) {

                if (htmlAttrib.Keys.Contains("class"))
                    htmlAttrib["class"] = defaultAppearanceClass + " " + htmlAttrib["class"].ToString();
                else
                    htmlAttrib.Add("class", defaultAppearanceClass);
            }
            //}

            //<div class="OptionItem OptionItem_Blue" id="@Model.ID">
            this.wrapperDiv = new TagBuilder("div");
            this.wrapperDiv.Attributes.Add("id", this.ID);
            this.wrapperDiv.Attributes.Add("name", this.ID + "WrapperDiv");
            this.wrapperDiv.MergeAttributes(new RouteValueDictionary(htmlAttrib));
            this.wrapperDiv.MergeAttributes(new RouteValueDictionary(this.Events));

            //<a id="optionLink" href="@Url.Action(@Model.URLActionName, @Model.URLControllerName, @Model.URLRouteValues)" >
            this.wrapperLink = new TagBuilder("a");
            this.wrapperLink.Attributes.Add("id", this.ID + "OptionLink");
            this.wrapperLink.Attributes.Add("name", this.ID + "OptionLink");
            this.wrapperLink.Attributes.Add("href", this.LinkURL.GetActionURL(ref urlHelper)); // urlHelper.Action(this.LinkURL.ActionName, this.LinkURL.ControllerName, this.LinkURL.RouteValues));
            //string.Format("@Url.Action(\"{0}\", \"{1}\", {2})", this.URLActionName, this.URLControllerName, this.URLRouteValues));

            //<div style="width:100%; height:100%;">
            this.innerDiv = new TagBuilder("div");
            this.innerDiv.Attributes.Add("id", this.ID + "InnerDiv");
            this.innerDiv.Attributes.Add("name", this.ID + "InnerDiv");
            //innerDiv.Attributes.Add("style", "width:100%; height:100%;");



            //<span style="position: absolute; background-color: rgb(255, 0, 0); top: 0px; right: 0px; height: 50px; width: 50px;"></span>
            this.notificationBox = new TagBuilder("span");
            var hasNotification = false;

            if (this.NotificationData != null)
                if (string.IsNullOrWhiteSpace(this.NotificationData.Content) == false) {
                    hasNotification = true;

                    this.notificationBox.Attributes.Add("id", this.ID + "NotificationBox");
                    this.notificationBox.Attributes.Add("name", this.ID + "NotificationBox");
                    this.notificationBox.AddCssClass(this.NotificationData.CssClass);
                    this.notificationBox.InnerHtml = this.NotificationData.Content;
                }

            //<img id="optionImage" src="@Url.Action(@Model.ImageURLActionName, @Model.ImageURLControllerName, @Model.ImageURLRouteValues)" 
            //                      alt="@Model.ImageAlternativeText" />
            //<br />
            this.innerImage = new TagBuilder("img");
            this.innerImage.Attributes.Add("id", this.ID + "InnerImage");
            this.innerImage.Attributes.Add("name", this.ID + "InnerImage");
            this.innerImage.Attributes.Add("src", this.ImageURL.GetActionURL(ref urlHelper));
            this.innerImage.Attributes.Add("alt", this.ImageAlternativeText);

            //<div id="optionText">@Model.Title</div>   OR  <span id="optionText">@Model.Title</span>
            this.innerText = new TagBuilder("div");
            this.innerText.Attributes.Add("id", this.Name + "OptionText");
            this.innerText.Attributes.Add("name", this.Name + "OptionText");
            this.innerText.Attributes.Add("data-details", this.Details);
            this.innerText.InnerHtml = this.Title;
            this.innerText.AddCssClass("OptionText");

            if (this.UserChangesFunction != null)
                this.UserChangesFunction(this);

            innerDiv.InnerHtml = (hasNotification) ? notificationBox.ToString(TagRenderMode.Normal) : "";
            innerDiv.InnerHtml += innerImage.ToString(TagRenderMode.Normal) + innerText.ToString(TagRenderMode.Normal);
            wrapperLink.InnerHtml = innerDiv.ToString(TagRenderMode.Normal);
            wrapperDiv.InnerHtml = wrapperLink.ToString(TagRenderMode.Normal);
            return new MvcHtmlString(wrapperDiv.ToString(TagRenderMode.Normal));
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }

        public static MvcHtmlString RoyaOptionItem(HtmlHelper html, string name, string title, Models.RouteModel linkURL, Models.RouteModel imageURL, string imageAlternativeText, object htmlAttributes, object events, OptionAppearance defaultAppearance, string details, Action<RoyaOptionItemTag> userChanges, RoyaMVC_EN.Models.RoyaOptionNotification notificationData) {
            var tmp = new RoyaOptionItemTag(html, name, title, linkURL, imageURL,
                                            imageAlternativeText, htmlAttributes, events, defaultAppearance, details, userChanges, notificationData);

            return tmp.ToHtmlTag();
        }
    }
}
