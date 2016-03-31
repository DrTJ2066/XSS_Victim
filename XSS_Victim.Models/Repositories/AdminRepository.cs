using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSS_Victim.Models.Repositories
{
    public class AdminRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        //public List<DAL.PartnershipRequest> GetNewJobRequests() {
        //    var res = this.Context.PartnershipRequest.Include("Users").Where(w => w.IsRead == true).ToList();
        //    return res;
        //}

        //public List<DAL.PartnershipRequest> GetAllJobRequests() {
        //    var res = this.Context.PartnershipRequest.Include("Users").ToList();
        //    return res;
        //}


        //public KeyValuePair<string, byte[]> GetResumeFile(long requestID, int userID) {
        //    var res = this.Context.PartnershipRequest.Where(q => q.RequestIndex.Equals(requestID) && q.UserID.Equals(userID))
        //                                             .First();
        //    return new KeyValuePair<string, byte[]>(res.ResumeFileName, res.GetFileContent());
        //}

        //public bool MarkAsRead(long requestID, int userID, bool isRead) {
        //    var res = this.Context.PartnershipRequest.Where(q => q.RequestIndex.Equals(requestID) && q.UserID.Equals(userID))
        //                                             .First();

        //    res.IsRead = isRead;
        //    this.Context.PartnershipRequest.ApplyCurrentValues(res);
        //    this.Context.SaveChanges();
        //    return true;
        //}

        public List<DAL.SitePages> GetSitePagesList() {
            var res = this.Context.SitePages.Include("SitePageFragments").ToList();

            foreach (var item in res) {
                item.PageContent = item.GetContent();
            }

            return res;
        }

        public List<DAL.SitePages> UpdateSettings(List<DAL.SitePages> model) {
            for (int i = 0; i < model.Count; i++) {
                model[i] = UpdateSitePage(model[i]);
            }

            return model;
        }

        public DAL.SitePages UpdateSitePage(DAL.SitePages item) {
            var page = this.Context.SitePages.FirstOrDefault(w => w.IDPage == item.IDPage);

            page.PageContent = item.PageContent;
            page.PageInternalName = item.PageInternalName;
            page.PageTitle = item.PageTitle;
            page.IsMetaEditable = item.IsMetaEditable;
            page.IsScript = item.IsScript;
            
            page.StoreHugeContentInFragments();

            this.Context.SaveChanges();
            return page;
        }

        public DAL.SitePages CreateNAddNewEmptyPage() {
            var newItem = new DAL.SitePages();
            newItem.IDPage = GetNewSitePageID();
            newItem.PageContent = " ";
            newItem.PageInternalName = "UntitledPage" + newItem.IDPage;
            newItem.PageTitle = "";
            newItem.Published = true;
            newItem.IsMetaEditable = true;
            newItem.IsScript = false;

            newItem.StoreHugeContentInFragments();

            this.Context.SitePages.Add(newItem);
            this.Context.SaveChanges();

            return newItem;
        }

        public int GetNewSitePageID() {
            var res = this.Context.SitePages;

            if (res.Count() > 0)
                return res.Max(w => w.IDPage) + 1;
            else
                return 1;
        }

        public void DeleteSitePage(int id) {
            var res = this.Context.SitePages.FirstOrDefault(w => w.IDPage == id);
            if (res != null) {
                this.Context.SitePages.Remove(res);
                this.Context.SaveChanges();
            }
        }

        public void PublishSitePage(int id, bool publish) {
            var res = this.Context.SitePages.FirstOrDefault(w => w.IDPage == id);
            if (res != null) {
                res.Published = publish;
                this.Context.SaveChanges();
            }
        }

        public int GetNewMessagesCount() {
            var res = this.Context.ContactUs.Count(w => w.IsRead != true);
            return res;
        }
    }
}
