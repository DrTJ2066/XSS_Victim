using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoyaMVC_EN.AccountManagement;

namespace XSS_Victim.Models.Repositories
{
    public class ContactUsMessagesRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        public long GetNewMessageID() {
            var res = this.Context.ContactUs.Select(w => w.IDMessage);

            if (res.Count() == 0)
                return 1;
            else
                return res.Max() + 1;
        }

        public RoyaContactUsModel AddNewMessage(RoyaContactUsModel newItem) {
            var tmp = ToDALModel(newItem);
            var res = AddNewMessage(tmp);
            return ToRoyaModel(res);
        }

        public DAL.ContactUs AddNewMessage(DAL.ContactUs newItem) {
            newItem.IDMessage = GetNewMessageID();

            newItem.MessageDateTimeGregorian = DateTime.Now;
            newItem.IsRead = false;

            this.Context.ContactUs.Add(newItem);
            this.Context.SaveChanges();

            return newItem;
        }

        public long GetUnreadMessagesCount() {
            return this.Context.ContactUs.Count(w => w.IsRead == false);
        }

        public List<DAL.ContactUs> GetUnreadMessagesList() {
            var res = this.Context.ContactUs.Where(w => w.IsRead == false);

            if (res.Count() > 0)
                return res.ToList();
            else
                return new List<DAL.ContactUs>();
        }

        public List<DAL.ContactUs> GetTotalMessagesList() {
            var res = this.Context.ContactUs;

            if (res.Count() > 0)
                return res.ToList();
            else
                return new List<DAL.ContactUs>();
        }

        public void DeleteMessage(long id) {
            var message = this.Context.ContactUs.FirstOrDefault(w => w.IDMessage == id);

            if (message != null) {
                this.Context.ContactUs.Remove(message);
                this.Context.SaveChanges();
            }
        }

        public DAL.ContactUs GetMessage(long id) {
            var res = this.Context.ContactUs.FirstOrDefault(w => w.IDMessage == id) ?? new DAL.ContactUs();
            return res;
        }

        public void MarkAsRead(long id, bool isRead) {
            var res = this.Context.ContactUs.FirstOrDefault(w => w.IDMessage == id);

            if (res != null) {
                res.IsRead = isRead;
                this.Context.SaveChanges();
            }
        }



        public DAL.ContactUs ToDALModel(RoyaMVC_EN.AccountManagement.RoyaContactUsModel royaModel) {
            var res = new DAL.ContactUs();

            res.EMail = royaModel.EMail;
            res.IDMessage = royaModel.MessageID;
            res.IsRead = royaModel.IsRead;
            res.MessageBody = royaModel.MessageBody;
            res.MessageDateTime = royaModel.MessageDateTime;
            res.MessageDateTimeGregorian = royaModel.MessageDateTimeGregorian;
            res.MessageSubject = royaModel.MessageSubject;
            res.Mobile = royaModel.Mobile;
            res.PersonFullName = royaModel.PersonFullName;
            res.WebSite = royaModel.WebSite;

            return res;
        }

        public RoyaMVC_EN.AccountManagement.RoyaContactUsModel ToRoyaModel(DAL.ContactUs model) {
            var res = new RoyaMVC_EN.AccountManagement.RoyaContactUsModel();

            res.EMail = model.EMail;
            res.MessageID = model.IDMessage;
            res.IsRead = model.IsRead ?? false;
            res.MessageBody = model.MessageBody;
            res.MessageDateTime = model.MessageDateTime;
            res.MessageDateTimeGregorian = model.MessageDateTimeGregorian.GetValueOrDefault();
            res.MessageSubject = model.MessageSubject;
            res.Mobile = model.Mobile;
            res.PersonFullName = model.PersonFullName;
            res.WebSite = model.WebSite;

            return res;
        }

    }
}

