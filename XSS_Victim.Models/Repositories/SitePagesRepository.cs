using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSS_Victim.Models.Repositories
{
    public class SitePagesRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        public int GetNewID() {
            var res = this.Context.SitePages.Select(w => w.IDPage);

            if (res.Count() == 0)
                return 1;
            else
                return res.Max() + 1;
        }

        public DAL.SitePages Add(DAL.SitePages newItem) {
            newItem.IDPage = GetNewID();
            newItem.StoreHugeContentInFragments();

            this.Context.SitePages.Add(newItem);
            this.Context.SaveChanges();

            return newItem;
        }

        public List<DAL.SitePages> GetList() {
            var tmp = this.Context.SitePages;

            if (tmp.Count() > 0) {
                var resList = tmp.ToList();
                for (int i = 0; i < resList.Count; i++) {
                    resList[i].GetContent();
                }
                return resList;
            }
            else
                return new List<DAL.SitePages>();
        }

        public DAL.SitePages GetSitePage(long id) {
            var item = this.Context.SitePages.FirstOrDefault(w => w.IDPage == id) ?? new DAL.SitePages();
            return item;
        }

        public DAL.SitePages GetSitePage(string internalName) {
            var res = this.Context.SitePages.FirstOrDefault(w => w.PageInternalName == internalName) ?? new DAL.SitePages() { IDPage = -1, PageContent ="", PageTitle ="" };
            if (res.IDPage != -1)
                res.PageContent = res.GetContent();

            return res;
        }

        public DAL.SitePages Update(DAL.SitePages theItem) {
            var res = this.Context.SitePages.FirstOrDefault(w => w.IDPage == theItem.IDPage);

            if (res == null) {
                res = DAL.SitePages.NewSitePage(GetNewID(), theItem.PageInternalName, theItem.PageTitle, theItem.PageContent);
                this.Context.SitePages.Add(res);
            }
            else {
                res.PageTitle = theItem.PageTitle;
                res.PageContent = theItem.PageContent;
                res.PageInternalName = theItem.PageInternalName;
                res.StoreHugeContentInFragments();
            }

            this.Context.SaveChanges();

            return res;
        }

        public void Delete(long id) {
            var item = this.Context.SitePages.FirstOrDefault(w => w.IDPage == id);

            if (item != null) {
                this.Context.SitePages.Remove(item);
                this.Context.SaveChanges();
            }
        }


    }
}