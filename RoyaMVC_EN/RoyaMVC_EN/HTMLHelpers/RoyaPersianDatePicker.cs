using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoyaMVC_EN.HTMLHelpers
{
    public class RoyaPersianDatePickerTag : RoyaTagBase
    {
        public string Day { get; set; }
        public int Month { get; set; }
        public string Year { get; set; }


        public RoyaPersianDatePickerTag(string name, string initValue, object htmlAttributes, object events)
            : base(name, name, htmlAttributes, events) {

            initValue = RoyaDateEngine.DateEngine.CorrectDate(initValue);
            var yearPart = initValue.Substring(0, 4);
            var monthPart = Convert.ToInt32(initValue.Substring(5, 2));
            var dayPart = initValue.Substring(8, 2);

            this.Day = dayPart;
            this.Month = monthPart;
            this.Year = yearPart;
        }

        public RoyaPersianDatePickerTag(string name, string initDay, int selectedMonthIndex, string initYear, object htmlAttributes, object events)
            : base(name, name, htmlAttributes, events) {

            this.Day = initDay;
            this.Month = selectedMonthIndex;
            this.Year = initYear;
        }

        public override MvcHtmlString ToHtmlTag() {
            //<div style="vertical-align: top; direction: rtl;">
            //    <input type="text" name="day" value="@ViewBag.CurrentDay" maxlength="2" style="width: 50px; text-align: center;" />
            //    <select style="vertical-align: top; width: 100px; height: 21px; font-size: small;">
            //        <option value="01">فروردین</option>
            //        <option value="02">اردیبهشت</option>
            //    </select>
            //    <input type="text" name="day" value="@ViewBag.CurrentYear" maxlength="4" style="width: 50px; text-align: center;" />
            //</div>

            var divTag = new TagBuilder("div");
            divTag.Attributes.Add("name", this.Name + "Wrapper");
            divTag.Attributes.Add("id", this.Name + "Wrapper");
            divTag.MergeAttribute("style", "vertical-align: top; direction: rtl;");

            //<input type="hidden" id="{0}" name="{0}" value="{2}/{3}/{1}" />
            var hiddenInputTag = new RoyaHiddenTag(this.Name, string.Format("{0}/{1}/{2}", this.Year, this.Month.ToString("00"), this.Day));

            //<input type="text" id="{0}Day" name="{0}Day" value="{1}" maxlength="2" style="width: 50px; text-align: center;" />
            var dayInputTag = new RoyaTextBoxTag(this.Name + "Day", this.Day, 2, new RouteValueDictionary(new { style = "width: 50px; text-align: center; margin-left: 4px;" }), null);

            //<input type="text" id="{0}Year" name="{0}Year" value="{2}" maxlength="4" style="width: 50px; text-align: center;" />
            var yearInputTag = new RoyaTextBoxTag(this.Name + "Year", this.Year, 4, new { style = "width: 50px; text-align: center;" }, null);

            var months = GetMonthsList();
            months[this.Month - 1].IsSelected = true;
            var monthSelectTag = new RoyaComboBoxTag(this.Name + "Month", months, new { style = "vertical-align: top; width: 100px; height: 21px; font-size: small; margin-left: 4px;" }, null);

            var res = divTag.ToString(TagRenderMode.StartTag) +
                      hiddenInputTag.ToHtmlTag() +
                      dayInputTag.ToHtmlTag() +
                      monthSelectTag.ToHtmlTag() +
                      yearInputTag.ToHtmlTag() +
                      divTag.ToString(TagRenderMode.EndTag);

            return new MvcHtmlString(res);
        }

        public override string ToHtmlString() {
            return this.ToHtmlTag().ToString();
        }

        private static List<RoyaComboBoxItemTag> GetMonthsList() {
            return new List<RoyaComboBoxItemTag>() { 
                        new RoyaComboBoxItemTag("فروردین", "01"),
                        new RoyaComboBoxItemTag("اردیبهشت", "02"),
                        new RoyaComboBoxItemTag("خرداد", "03"),
                        new RoyaComboBoxItemTag("تیر", "04"),
                        new RoyaComboBoxItemTag("مرداد", "05"),
                        new RoyaComboBoxItemTag("شهریور", "06"),
                        new RoyaComboBoxItemTag("مهر", "07"),
                        new RoyaComboBoxItemTag("آبان", "08"),
                        new RoyaComboBoxItemTag("آذر", "09"),
                        new RoyaComboBoxItemTag("دی", "10"),
                        new RoyaComboBoxItemTag("بهمن", "11"),
                        new RoyaComboBoxItemTag("اسفند", "12")
            };
        }




        #region Static

        public static MvcHtmlString RoyaPersianDatePicker(string name, string initValue) {
            initValue = RoyaDateEngine.DateEngine.CorrectDate(initValue);

            var yearPart = initValue.Substring(0, 4);
            var monthPart = Convert.ToInt32(initValue.Substring(5, 2));
            var dayPart = initValue.Substring(8, 2);

            return RoyaPersianDatePicker(name, dayPart, monthPart, yearPart);
        }

        public static MvcHtmlString RoyaPersianDatePicker(string name, string initDay, int selectedMonthIndex, string initYear) {
            //<div style="vertical-align: top; direction: rtl;">
            //    <input type="text" name="day" value="@ViewBag.CurrentDay" maxlength="2" style="width: 50px; text-align: center;" />
            //    <select style="vertical-align: top; width: 100px; height: 21px; font-size: small;">
            //        <option value="01">فروردین</option>
            //        <option value="02">اردیبهشت</option>
            //    </select>
            //    <input type="text" name="day" value="@ViewBag.CurrentYear" maxlength="4" style="width: 50px; text-align: center;" />
            //</div>

            var divTag = new TagBuilder("div");
            divTag.Attributes.Add("name", name + "Wrapper");
            divTag.Attributes.Add("id", name + "Wrapper");
            divTag.MergeAttribute("style", "vertical-align: top; direction: rtl;");

            //<input type="hidden" id="{0}" name="{0}" value="{2}/{3}/{1}" />
            var hiddenInputTag = new RoyaHiddenTag(name, string.Format("{0}/{1}/{2}", initYear, selectedMonthIndex.ToString("00"), initDay));

            //<input type="text" id="{0}Day" name="{0}Day" value="{1}" maxlength="2" style="width: 50px; text-align: center;" />
            var dayInputTag = new RoyaTextBoxTag(name + "Day", initDay, 2, new { style = "width: 50px; text-align: center; margin-left: 4px;" }, null);

            //<input type="text" id="{0}Year" name="{0}Year" value="{2}" maxlength="4" style="width: 50px; text-align: center;" />
            var yearInputTag = new RoyaTextBoxTag(name + "Year", initYear, 4, new { style = "width: 50px; text-align: center;" }, null);

            var months = GetMonthsList();
            months[selectedMonthIndex - 1].IsSelected = true;
            var monthSelectTag = new RoyaComboBoxTag(name + "Month", months, new { style = "vertical-align: top; width: 100px; height: 21px; font-size: small; margin-left: 4px;" }, null);

            var res = divTag.ToString(TagRenderMode.StartTag) +
                      hiddenInputTag.ToHtmlTag() +
                      dayInputTag.ToHtmlTag() +
                      monthSelectTag.ToHtmlTag() +
                      yearInputTag.ToHtmlTag() +
                      divTag.ToString(TagRenderMode.EndTag);

            //var res = string.Format("<div id=\"{0}Wrapper\" style=\"vertical-align: top; direction: rtl;\">\n" +
            //                        "  <input type=\"hidden\" id=\"{0}\" name=\"{0}\" value=\"{2}/{3}/{1}\" />" +  //onchange=\"valueChanged();\"
            //                        "  <input type=\"text\" id=\"{0}Day\" name=\"{0}Day\" value=\"{1}\" maxlength=\"2\" style=\"width: 50px; text-align: center;\" />" +
            //                        "  <select id=\"{0}Month\" style=\"vertical-align: top; width: 100px; height: 21px; font-size: small;\">" +
            //                        "       <option value=\"01\">فروردین</option>" +
            //                        "       <option value=\"02\">اردیبهشت</option>" +
            //                        "       <option value=\"03\">خرداد</option>" +
            //                        "       <option value=\"04\">تیر</option>" +
            //                        "       <option value=\"05\">مرداد</option>" +
            //                        "       <option value=\"06\">شهریور</option>" +
            //                        "       <option value=\"07\">مهر</option>" +
            //                        "       <option value=\"08\">آبان</option>" +
            //                        "       <option value=\"09\">آذر</option>" +
            //                        "       <option value=\"10\">دی</option>" +
            //                        "       <option value=\"11\">بهمن</option>" +
            //                        "       <option value=\"12\">اسفند</option>" +
            //                        "   </select>" +
            //                        "   <input type=\"text\" id=\"{0}Year\" name=\"{0}Year\" value=\"{2}\" maxlength=\"4\" style=\"width: 50px; text-align: center;\" />" +
            //                        "</div>", name, initDay, initYear, selectedMonthIndex.ToString("00"));

            return new MvcHtmlString(res);
        }

        #endregion
    }
}
