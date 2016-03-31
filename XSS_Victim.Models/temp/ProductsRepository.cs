using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RoyaMVC_EN.Models;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace XSS_Victim.Models.Repositories
{
    public class ProductsRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        //public int GetNewIDGalleryItem() {
        //    var res = this.Context.SamplesGallery.Select(w => w.IDGalleryItem);
        //    return (res.Count() > 0) ? res.Max() + 1 : 1;
        //}

        //public void AddPictureGallery(DAL.SamplesGallery item) {
        //    var newItem = new DAL.SamplesGallery();

        //    newItem.IDGalleryItem = GetNewIDGalleryItem();
        //    newItem.CategoryID = item.CategoryID;
        //    newItem.ImageDescription = item.ImageDescription;
        //    newItem.ItemTitle = item.ItemTitle;
        //    newItem.ImagePath = item.ImagePath;
        //    newItem.ThumbnailImagePath = item.ThumbnailImagePath;
        //    newItem.Published = item.Published;
        //    newItem.SortOrder = item.SortOrder;

        //    this.Context.AddToSamplesGallery(newItem);
        //    this.Context.SaveChanges();
        //}

        //public void UpdateGalleryItem(DAL.SamplesGallery item) {
        //    var newItem = this.Context.SamplesGallery.FirstOrDefault(w => w.IDGalleryItem == item.IDGalleryItem);

        //    newItem.CategoryID = item.CategoryID;
        //    newItem.ImageDescription = item.ImageDescription;
        //    newItem.ItemTitle = item.ItemTitle;
        //    newItem.ImagePath = item.ImagePath;
        //    newItem.ThumbnailImagePath = item.ThumbnailImagePath;
        //    newItem.Published = item.Published;
        //    newItem.SortOrder = item.SortOrder;

        //    this.Context.SaveChanges();
        //}

        //public DAL.SamplesGallery GetSamplesGalleryItem(long id) {
        //    var res = this.Context.SamplesGallery.FirstOrDefault(w => w.IDGalleryItem == id);
        //    return res ?? new DAL.SamplesGallery();
        //}

        //public List<DAL.SamplesGallery> GetGalleryList(int count = 0) {
        //    var items = this.Context.SamplesGallery;

        //    if (items.Count() == 0)
        //        return new List<DAL.SamplesGallery>();
        //    else {
        //        if (count > 0)
        //            return items.Take(count).ToList();
        //        else
        //            return items.ToList();
        //    }
        //}
        
        //public bool DeleteGalleryItem(int id) {
        //    var tmp = this.Context.SamplesGallery.FirstOrDefault(w => w.IDGalleryItem == id);

        //    if (tmp == null)
        //        return false;
        //    else {
        //        this.Context.SamplesGallery.DeleteObject(tmp);
        //        this.Context.SaveChanges();
        //        return true;
        //    }
        //}

        //public bool PublishGalleryItem(int id, bool isPublished) {
        //    var tmp = this.Context.SamplesGallery.FirstOrDefault(w => w.IDGalleryItem == id);

        //    if (tmp == null)
        //        return false;
        //    else {
        //        tmp.Published = isPublished;
        //        this.Context.SaveChanges();
        //        return true;
        //    }
        //}

        //public DAL.SamplesGallery ChangeOrderGalleryItem(int id, int newOrder) {
        //    var p = this.GetSamplesGalleryItem(id);
        //    p.SortOrder = newOrder;
        //    this.Context.SaveChanges();
        //    return p;
        //}

        //public DAL.SamplesGallery GetEmptyGalleryItem() {
        //    var res = new DAL.SamplesGallery() { ItemTitle = "", CategoryID = 0, ImageDescription = "---" };

        //    var tmp = this.Context.SamplesGallery.Select(w => w.SortOrder);
        //    res.SortOrder = (tmp.Count() > 0) ? tmp.Max() + 1 : 1;

        //    return res;
        //}




        public List<DAL.Products> GetThumbnailList(int count = 0) {
            var res = this.Context.Products.OrderBy(w => w.SortOrder);

            if ((count == 0) || (res.Count() < count))
                return res.ToList();
            else
                return res.Take(count).ToList();
        }

        public List<DAL.Products> GetProductsByCategoryID(int idCategory) {
            var res = this.Context.Products.Where(w => w.CategoryID == idCategory);

            if (res.Count() > 0)
                return res.ToList();
            else
                return new List<DAL.Products>();
        }

        public List<DAL.ProductCategories> GetCategoriesList() {
            var res = this.Context.ProductCategories.ToList();
            return res;
        }

        public List<DAL.ProductCategories> GetCategoriesListWithProducts() {
            var res = this.Context.ProductCategories.Include("Products")
                                                    .ToList();
            return res;
        }





        public DAL.Products GetCatalogDetails(int id) {
            var res = this.Context.Products.Include("ProductCatalogPages").FirstOrDefault(w => w.IDProduct == id);
            if (res == null)
                res = new DAL.Products() { IDProduct = -1 };

            return res;
        }

        public List<DAL.Products> GetProductsList() {
            var res = this.Context.Products.ToList();
            return res;
        }

        public DAL.Products AddNewProduct(DAL.Products item) {
            var newItem = new DAL.Products();

            newItem.IDProduct = GetNewProductID();
            newItem.CategoryID = item.CategoryID;
            newItem.LongDescription = item.LongDescription;
            newItem.ProductTitle = item.ProductTitle;
            newItem.Published = item.Published;
            newItem.ShortDescription = item.ShortDescription;
            newItem.ThumbnailImagePath = item.ThumbnailImagePath;
            newItem.CatalogPath = string.IsNullOrWhiteSpace(item.CatalogPath) ? "" : item.CatalogPath;
            newItem.SortOrder = item.SortOrder;

            this.Context.AddToProducts(newItem);
            this.Context.SaveChanges();

            return newItem;
        }

        public int GetNewProductID() {
            var res = this.Context.Products.Select(w => w.IDProduct);
            return (res.Count() > 0) ? res.Max() + 1 : 1;
        }

        public DAL.Products UpdateProduct(DAL.Products item) {
            var product = this.Context.Products.FirstOrDefault(w => w.IDProduct == item.IDProduct);

            if (product != null) {
                //product.IDProduct = GetNewProductID();
                product.CategoryID = item.CategoryID;
                product.LongDescription = item.LongDescription;
                product.ProductTitle = item.ProductTitle;
                product.Published = item.Published;
                product.ShortDescription = item.ShortDescription;
                product.ThumbnailImagePath = item.ThumbnailImagePath;
                product.CatalogPath = item.CatalogPath;
                product.SortOrder = item.SortOrder;

                //this.Context.Products.ApplyCurrentValues(product);
                this.Context.SaveChanges();
                return product;
            }
            else
                return new DAL.Products() { IDProduct = -1 };
        }

        public bool DeleteProduct(int id) {
            var tmp = this.Context.Products.FirstOrDefault(w => w.IDProduct == id);
            if (tmp == null)
                return false;
            else {
                this.Context.Products.DeleteObject(tmp);
                this.Context.SaveChanges();
                return true;
            }
        }

        public bool PublishProduct(int id, bool publish) {
            var tmp = this.Context.Products.FirstOrDefault(w => w.IDProduct == id);
            if (tmp == null)
                return false;
            else {
                tmp.Published = publish;
                this.Context.SaveChanges();
                return true;
            }
        }

        public DAL.Products GetProduct(int id) {
            var res = this.Context.Products.Include("ProductCatalogPages")
                                           .Include("ProductCatalogPages.ProductCatalogPagesFragments").FirstOrDefault(w => w.IDProduct == id);
            if (res == null)
                res = new DAL.Products() { IDProduct = -1 };

            return res;
        }

        public List<DAL.Products> GetProductsMenu() {
            var res = this.Context.Products.Where(w => w.Published == true);
            if (res.Count() > 0)
                return res.OrderBy(w => w.SortOrder).ToList();
            else
                return new List<DAL.Products>();
        }

        public bool ImageChanged(DAL.Products product, Func<string, string> mapPath) {
            var p = this.GetProduct(product.IDProduct);

            if(p.ThumbnailImagePath != product.ThumbnailImagePath)
                return true;

            if ((string.IsNullOrWhiteSpace(p.ThumbnailImagePath) == false) &&
                (string.IsNullOrWhiteSpace(product.ThumbnailImagePath) == false)) {
                var path1 = mapPath(p.ThumbnailImagePath);
                var path2 = mapPath(product.ThumbnailImagePath);

                if (new FileInfo(path1).Length != new FileInfo(path2).Length)
                    return true;
            }

            return false;
        }

        public DAL.Products ChangeOrder(int id, int newOrder) {
            var p = this.GetProduct(id);
            p.SortOrder = newOrder;
            this.Context.SaveChanges();
            return p;
        }

        public List<SelectListItem> GetProductsAsSelectList() {
            var tmp = this.Context.Products;

            if (tmp.Count() > 0) {
                var res = tmp.OrderBy(x => x.SortOrder)
                             .ToList()
                             .Select(w => new SelectListItem() { Selected = false, Text = w.ProductTitle, Value = string.Format("{0}", w.IDProduct) })
                             .ToList();
                return res;
            }
            else
                return new List<SelectListItem>();
        }

    }
}
