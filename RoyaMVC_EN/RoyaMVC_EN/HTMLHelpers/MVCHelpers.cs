using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public static class MVCHelpers
    {
        public static RouteValueDictionary Attr(object htmlAttributes) {
            RouteValueDictionary result = new RouteValueDictionary();
            if (htmlAttributes != null) {
                foreach (System.ComponentModel.PropertyDescriptor property in System.ComponentModel.TypeDescriptor.GetProperties(htmlAttributes)) {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }
            return result;
        }


        public static MvcHtmlString Image(this HtmlHelper helper, string name, string url, string altText, object htmlAttributes) {
            var img = new RoyaImageTag(name, url, altText, new RouteValueDictionary(htmlAttributes), TagRenderMode.SelfClosing);
            return img.ToHtmlTag();
        }

        public static MvcHtmlString ImageFor(this HtmlHelper htmlHelper, string action, object routeValues, string altText, object htmlAttributes) {
            // <img src='@Url.Action("GetCandidateThumbnailImage", new { id = @item.ID })' alt="@item.FirstName @item.LastName"  />
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", string.Format("@Url.Action(\"{0}\", {1})", action, routeValues));
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }



        public static MvcHtmlString RoyaRadioButton(this HtmlHelper html, string name, string groupName, string radioButtonTitle, string value, object htmlAttributesInput, object htmlAttributesLabel, object htmlAttributesSpan, object events) {
            return RoyaRadioButtonTag.RoyaRadioButton(name, groupName, radioButtonTitle, value, htmlAttributesInput, htmlAttributesLabel, htmlAttributesSpan, events);
        }

        public static MvcHtmlString RoyaRadioButton(this HtmlHelper html, string name, string groupName, string radioButtonTitle, string value, object htmlAttributes, object events) {
            return RoyaRadioButtonTag.RoyaRadioButton(name, groupName, radioButtonTitle, value, htmlAttributes, events);
        }

        public static MvcHtmlString RoyaCheckBox(this HtmlHelper html, string name, string checkBoxTitle, string value, object htmlAttributes, object events) {
            return RoyaCheckBoxTag.RoyaCheckBox(name, checkBoxTitle, value, htmlAttributes, events);
        }



        
        public static MvcHtmlString RoyaOptionItem(this HtmlHelper html, string name, string title, Models.RouteModel linkURL, Models.RouteModel imageURL, RoyaMVC_EN.Models.RoyaOptionNotification notificationData = null) {
            return RoyaOptionItem(html, name, title, linkURL, imageURL, title, null, null, OptionAppearance.OptionItem, "", null, notificationData);
        }

        public static MvcHtmlString RoyaOptionItem(this HtmlHelper html, string name, string title, Models.RouteModel linkURL, Models.RouteModel imageURL, string imageAlternativeText, object htmlAttributes, object events, OptionAppearance defaultAppearance, string details, Action<RoyaOptionItemTag> userChanges, RoyaMVC_EN.Models.RoyaOptionNotification notificationData = null) {
            return RoyaOptionItemTag.RoyaOptionItem(html, name, title, linkURL, imageURL,
                                            imageAlternativeText, htmlAttributes, events, defaultAppearance, details, userChanges, notificationData);
        }

        public static MvcHtmlString RoyaImage(this HtmlHelper html, string name, Models.RouteModel imageURL, string imageAlternativeText, object htmlAttributes, object events) {
            return RoyaImageTag.RoyaImage(html, name, imageURL, imageAlternativeText, htmlAttributes, events);
        }

    }
}


public enum OptionAppearance 
{
    OptionItem, ThumbnailItem
}