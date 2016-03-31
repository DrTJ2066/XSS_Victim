using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSS_Victim.DAL
{    
    public partial class SitePages
    {
        public string GetContent(int count = 0) {
            var res = "";

            if (this.HasFragments.Value) {
                foreach (var item in this.SitePageFragments) {
                    res += item.PageContent;
                }
            }
            else
                res = this.PageContent;

            if (count > 4)
                return res.Substring(0, count - 3) + "...";
            else
                return res;
        }

        public void StoreHugeContentInFragments() {
            if (this.PageContent.Length >= 4000) {
                var fragments = RoyaMVC_EN.HelperClass.SplitBigString(this.PageContent, 4000);

                this.SitePageFragments.Clear();

                for (int i = 0; i < fragments.Count; i++) {
                    var item = new SitePageFragments();
                    item.FragmentIndex = i;
                    item.PageContent = fragments[i];
                    item.PageID = this.IDPage;

                    this.SitePageFragments.Add(item);
                }

                this.HasFragments = true;
                this.PageContent = "";
            }
            else {
                this.HasFragments = false;
            }
        }

        public static SitePages NewSitePage(int pageID, string internalName, string title = "---", string content = "") {
            var tmp = new DAL.SitePages();

            tmp.IDPage = pageID;
            tmp.PageContent = content;
            tmp.PageInternalName = internalName;
            tmp.PageTitle = title;

            tmp.StoreHugeContentInFragments();

            return tmp;
        }
    }
    // */










    //public partial class PartnershipRequest
    //{
    //    public byte[] GetFileContent() {
    //        if (this.HasFragments.Value) {
    //            var res = new List<byte>();

    //            foreach (var item in this.PartnershipRequestResumeFragments) {
    //                res.AddRange(item.ResumeContent);
    //            }

    //            return res.ToArray();
    //        }
    //        else
    //            return this.ResumeContent;
    //    }

    //    public void StoreHugeContentInFragments() {
    //        if (this.ResumeContent.Length >= 60000) {
    //            var fragments = RoyaMVC.HelperClass.SplitBigBytes(this.ResumeContent, 60000);

    //            this.PartnershipRequestResumeFragments.Clear();

    //            for (int i = 0; i < fragments.Count; i++) {
    //                var item = new PartnershipRequestResumeFragments();
    //                item.UserID = this.UserID;
    //                item.RequestIndex = this.RequestIndex;
    //                item.ResumeFileFragmentIndex = i;
    //                item.ResumeContent = fragments[i];

    //                this.PartnershipRequestResumeFragments.Add(item);
    //            }

    //            this.HasFragments = true;
    //            this.ResumeContent = new byte[0];
    //        }
    //        else {
    //            this.HasFragments = false;
    //        }
    //    }
    //}

    //public partial class News
    //{
    //    public string GetContent(int count = 0) {
    //        var res = "";

    //        if (this.HasFragments.Value) {
    //            foreach (var item in this.NewsContentFragments) {
    //                res += item.NewsContent;
    //            }
    //        }
    //        else
    //            res = this.NewsContent;

    //        if (count > 4)
    //            return res.Substring(0, count - 3) + "...";
    //        else
    //            return res;
    //    }

    //    public void StoreHugeContentInFragments() {
    //        if (this.NewsContent.Length >= 4000) {
    //            var fragments = RoyaMVC.HelperClass.SplitBigString(this.NewsContent, 4000);

    //            this.NewsContentFragments.Clear();

    //            for (int i = 0; i < fragments.Count; i++) {
    //                var item = new NewsContentFragments();
    //                item.NewsFragmentIndex = i;
    //                item.NewsContent = fragments[i];
    //                item.IDNews = this.IDNews;
 
    //                this.NewsContentFragments.Add(item);
    //            }

    //            this.HasFragments = true;
    //            this.NewsContent = "";
    //        }
    //        else {
    //            this.HasFragments = false;
    //        }
    //    }
    //}
}
