using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace XSS_Victim.Models.Repositories
{
    public enum MediaTypes { Video, Picture, Both }
    public enum PublishStatus { Published, UnPublished, All }

    public class MediaGalleryRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        public int GetNewID() {
            var res = this.Context.MediaGallery.Select(w => w.IDGalleryItem);
            return (res.Count() > 0) ? res.Max() + 1 : 1;
        }

        public void Add(DAL.MediaGallery item) {
            var newItem = new DAL.MediaGallery();

            newItem.IDGalleryItem = GetNewID();
            newItem.AlbumID = item.AlbumID;
            newItem.ItemDescription = item.ItemDescription;
            newItem.ItemTitle = item.ItemTitle;
            newItem.MediaTags = item.MediaTags;
            newItem.MediaTypeID = item.MediaTypeID;
            newItem.Published = item.Published;
            newItem.ResourcePath = item.ResourcePath;
            newItem.SortOrder = item.SortOrder;
            newItem.ThumbnailImagePath = item.ThumbnailImagePath;

            this.Context.MediaGallery.Add(newItem);
            this.Context.SaveChanges();
        }

        public void Update(DAL.MediaGallery item) {
            var newItem = this.Context.MediaGallery.FirstOrDefault(w => w.IDGalleryItem == item.IDGalleryItem);

            newItem.AlbumID = item.AlbumID;
            newItem.ItemDescription = item.ItemDescription;
            newItem.ItemTitle = item.ItemTitle;
            newItem.MediaTags = item.MediaTags;
            newItem.MediaTypeID = item.MediaTypeID;
            newItem.Published = item.Published;
            newItem.ResourcePath = item.ResourcePath;
            newItem.SortOrder = item.SortOrder;
            newItem.ThumbnailImagePath = item.ThumbnailImagePath;

            this.Context.SaveChanges();
        }

        public DAL.MediaGallery GetItem(long id) {
            var res = this.Context.MediaGallery.Include("MediaTypes").FirstOrDefault(w => w.IDGalleryItem == id);
            return res ?? new DAL.MediaGallery();
        }

        public List<DAL.MediaGallery> GetGalleryList(MediaTypes mediaType, PublishStatus status, int count = 0) {
            IEnumerable<DAL.MediaGallery> items ;
            var videoID = this.Context.MediaTypes.FirstOrDefault(w=> w.MediaTypeTitle == "ویدیو").IDMediaType;
            var pictureID = this.Context.MediaTypes.FirstOrDefault(w=> w.MediaTypeTitle == "عکس").IDMediaType;
            
            switch (mediaType) {
                case MediaTypes.Video:
                    items = this.Context.MediaGallery.Include("MediaTypes").Where(w => w.MediaTypeID == videoID);
                    break;

                case MediaTypes.Picture:
                    items = this.Context.MediaGallery.Include("MediaTypes").Where(w => w.MediaTypeID == pictureID);
                    break;

                case MediaTypes.Both:
                default:
                    items = this.Context.MediaGallery.Include("MediaTypes");
                    break;
            }

            if (status != PublishStatus.All) {
                items = items.Where(w => w.Published == (status == PublishStatus.Published));
            }

            if (items.Count() == 0)
                return new List<DAL.MediaGallery>();
            else {
                if (count > 0)
                    return items.Take(count).ToList();
                else
                    return items.ToList();
            }
        }

        public bool Delete(int id) {
            var tmp = this.Context.MediaGallery.FirstOrDefault(w => w.IDGalleryItem == id);

            if (tmp == null)
                return false;
            else {
                this.Context.MediaGallery.Remove(tmp);
                this.Context.SaveChanges();
                return true;
            }
        }

        public bool PublishItem(int id, bool isPublished) {
            var tmp = this.Context.MediaGallery.FirstOrDefault(w => w.IDGalleryItem == id);

            if (tmp == null)
                return false;
            else {
                tmp.Published = isPublished;
                this.Context.SaveChanges();
                return true;
            }
        }

        public DAL.MediaGallery ChangeOrder(int id, int newOrder) {
            var tmp = this.GetItem(id);
            tmp.SortOrder = newOrder;
            this.Context.SaveChanges();
            return tmp;
        }

        public DAL.MediaGallery GetEmptyItem() {
            var res = new DAL.MediaGallery() { IDGalleryItem = GetNewID(), ItemTitle = "", ItemDescription = "---" };

            var tmp = this.Context.MediaGallery.Select(w => w.SortOrder);
            res.SortOrder = (tmp.Count() > 0) ? tmp.Max() + 1 : 1;

            return res;
        }


        public List<SelectListItem> GetMediaTypesList() {
            var res = this.Context.MediaTypes
                                  .ToList()
                                  .Select(w => new SelectListItem() { Selected = false, Text = w.MediaTypeTitle, Value = w.IDMediaType.ToString() })
                                  .ToList();

            res.First().Selected = true;
            return res;
        }

        public int GetMediaTypeID(MediaTypes mediaType) {
            var res = -1;

            switch (mediaType) {
                case MediaTypes.Video:
                    res = this.Context.MediaTypes.FirstOrDefault(w => w.MediaTypeTitle == "Video").IDMediaType;
                    break;
                case MediaTypes.Picture:
                    res = this.Context.MediaTypes.FirstOrDefault(w => w.MediaTypeTitle == "Picture").IDMediaType;
                    break;

                case MediaTypes.Both:
                default:
                    res = -1;
                    break;
            }

            return res;
        }

    }
}
