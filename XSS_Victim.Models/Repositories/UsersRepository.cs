using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using RoyaMVC_EN.AccountManagement;
using System.Web.Mvc;

namespace XSS_Victim.Models.Repositories
{
    public class UsersRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        public UsersRepository() : base() { }

        public void SetCurrentUser(string userName) {
            var user = this.Context.Users.FirstOrDefault(w => w.UserName == userName);
            if (user != null) {
                CurrentUser.DisplayName = user.UserFullName;
                CurrentUser.LastUpdate = DateTime.Now;
                CurrentUser.UserID = user.IDUser;
                CurrentUser.UserName = user.UserName;
            }
        }

        public DAL.Users GetUserSettings(long userID) {
            var res = this.Context.Users.Where(w => w.IDUser == userID).First();
            return res;
        }

        public bool UpdateUserSettings(DAL.Users newUserData) {
            var res = this.Context.Users.Where(w => w.IDUser == newUserData.IDUser).First();

            res.UserFullName = newUserData.UserFullName;
            res.EMail = newUserData.EMail;
            res.Telephone = newUserData.Telephone;
            res.Mobile = newUserData.Mobile;
            res.Description = newUserData.Description;
            res.WebAddress = newUserData.WebAddress;
            res.AddressCountryID = newUserData.AddressCountryID;
            res.AddressProvinceID = newUserData.AddressProvinceID;
            res.AddressCityID = newUserData.AddressCityID;
            res.Address = newUserData.Address;
            
            this.Context.Users.ApplyCurrentValues(res);
            this.Context.SaveChanges();
            return true;
        }

        public List<DAL.Users> GetUsersList() {
            var res = this.Context.Users.Include("webpages_Roles").ToList();
            return res;
        }

        public bool ActivateUser(int userID, bool active) {
            var user = this.Context.Users.FirstOrDefault(w => (w.IDUser == userID));
            if (user == null)
                return false;

            user.IsActive = active;

            this.Context.SaveChanges();
            return true;
        }

        public bool IsActive(string userName) {
            var usersList = this.Context.Users.Where(w => (w.UserName == userName));
            if (usersList.Count() == 0)
                return false;

            var user = usersList.First(w => w.UserName == userName);
            return user.IsActive;
        }


        public long GetNewUserID() {
            var res = this.Context.Users.Select(w => w.IDUser);

            if (res.Count() == 0)
                return 1;
            else
                return res.Max() + 1;
        }

        public RoyaMVC_EN.AccountManagement.RegisterModel GetUserByUserName(string userName) {
            var res = this.Context.Users.Include("Genders")
                                        .Include("webpages_Roles")
                                        .Where(w => w.UserName.Equals(userName));

            if (res == null)
                return new RoyaMVC_EN.AccountManagement.RegisterModel();
            else if (res.Count() == 0)
                return new RoyaMVC_EN.AccountManagement.RegisterModel();
            else
                return res.AsEnumerable()
                          .Select(w => new RoyaMVC_EN.AccountManagement.RegisterModel() {
                              IDUser = w.IDUser,
                              UserName = w.UserName,
                              UserFullName = w.UserFullName,
                              Password = w.Password,
                              EMail = w.EMail,
                              AddressCityName = w.AddressCityID,
                              AddressCountryID = w.AddressCountryID,
                              AddressProvinceName = w.AddressProvinceID,
                              Description = w.Description
                          })
                          .First();
        }

        public void ResetPassword(string username, string password) {
            var user = this.Context.Users.FirstOrDefault(w => w.UserName.Equals(username));
            user.Password = password;
            this.Context.SaveChanges();
        }

        public void Delete(int id) {
            var user = this.Context.Users.FirstOrDefault(w => (w.IDUser == id));
            if (user != null) {
                this.Context.Users.Remove(user);
                this.Context.SaveChanges();
            }
        }

        public DAL.Users GetUser(int id) {
            var user = this.Context.Users.FirstOrDefault(w => (w.IDUser == id));
            if (user == null)
                return new DAL.Users() { IDUser = -1 };
            else
                return user;
        }

        public List<DAL.webpages_Roles> GetRolesList() {
            var res = this.Context.webpages_Roles.ToList();
            return res;
        }

        public void AddRemoveRole(int id, int roleID) {
            var user = this.Context.Users.Include("webpages_Roles").FirstOrDefault(w => (w.IDUser == id));
            if (user != null) {
                var userRole = user.webpages_Roles.FirstOrDefault(w => w.RoleID == roleID);
                var tmpRole = this.Context.webpages_Roles.FirstOrDefault(w => w.RoleID == roleID);
                
                if (tmpRole != null) {
                    if (userRole == null) {
                        user.webpages_Roles.Add(tmpRole);
                    }
                    else {
                        user.webpages_Roles.Remove(tmpRole);
                    }
                }

                this.Context.SaveChanges();
            }
        }
    }
}
