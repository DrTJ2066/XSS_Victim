using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN
{
    public class VisitorsCounterViewModel
    {
        public long Today { get; set; }
        public long Yesterday { get; set; }
        public long ThisWeek { get; set; }
        public long ThisMonth { get; set; }
        public long TotalVisits { get; set; }
        public long TotalNews { get; set; }
        public long TotalVotes { get; set; }
        public long TotalLaws { get; set; }
        public string LastWebsiteUpdate { get; set; }
        public long TotalArticles { get; set; }
        
        public string ToHTMLTagsStrign() {
            var res = "<ul><li>بازدید امروز: {Today}</li><li>بازدید دیروز: {Yesterday}</li><li>بازدید هفته: {ThisWeek}</li>" +
                      "<li>بازدید ماه: {ThisMonth}</li><li>کل بازدیدها: {TotalVisits}</li><li>خبرها : {TotalNews}</li>" +
                      "<li>آرای وحدت رویه: {TotalVotes}</li><li>قوانین : {TotalLaws}</li><li>قوانین : {TotalArticles}</li>" +
                      "<li>تاریخ به‌روزشدن سایت: {LastWebsiteUpdate}</li></ul>"
                      .Replace("{Today}", this.Today.ToString())
                      .Replace("{Yesterday}", this.Yesterday.ToString())
                      .Replace("{ThisWeek}", this.ThisWeek.ToString())
                      .Replace("{ThisMonth}", this.ThisMonth.ToString())
                      .Replace("{TotalVisits}", this.TotalVisits.ToString())
                      .Replace("{TotalNews}", this.TotalNews.ToString())
                      .Replace("{TotalVotes}", this.TotalVotes.ToString())

                      .Replace("{TotalLaws}", this.TotalLaws.ToString())
                      .Replace("{LastWebsiteUpdate}", this.LastWebsiteUpdate.ToString())
                      .Replace("{TotalArticles}", this.TotalArticles.ToString());

            return res;
        }
    }
}
