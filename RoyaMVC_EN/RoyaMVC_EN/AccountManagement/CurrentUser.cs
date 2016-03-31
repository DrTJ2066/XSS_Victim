using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.AccountManagement
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string DisplayName { get; set; }
        public static DateTime LastUpdate { get; set; }
        public static string UserTypeID { get; set; }
        public static string UserTypeName { get; set; }
        public static string ProfileImageURL { get; set; }


        public static List<KeyValuePair<int, string>> UserRolesList = new List<KeyValuePair<int, string>>();

        public static void ClearData() {
            UserID = -1;
            UserName = "";
            DisplayName = "";
            UserTypeID = "";
            UserTypeName = "";
            UserRolesList = new List<KeyValuePair<int, string>>();
            LastUpdate = DateTime.MinValue;
        }

        public static UserData Clone() {
            var res = new UserData() {
                UserID = UserID,
                UserName = UserName,
                DisplayName = DisplayName,
                UserTypeID = UserTypeID,
                UserTypeName = UserTypeName,
                LastUpdate = LastUpdate
            };

            return res;
        }

        public static bool IsInRole(string roleName) {
            return CurrentUser.UserRolesList.Count(w => w.Value == roleName) > 0;
        }

        public static void AddRoles(int roleID, string roleName) {
            if (CurrentUser.IsInRole(roleName))
                return;

            CurrentUser.UserRolesList.Add(new KeyValuePair<int, string>(roleID, roleName));

            CurrentUser.RebuildRoleNames();
        }

        public static void AddRoles(IEnumerable<KeyValuePair<int, string>> rolesList) {
            foreach (var item in rolesList) {
                if (CurrentUser.IsInRole(item.Value))
                    continue;

                CurrentUser.UserRolesList.Add(item);
            }

            CurrentUser.RebuildRoleNames();
        }
        
        private static void RebuildRoleNames() {
            CurrentUser.UserTypeName = string.Join(", ", UserRolesList.Select(w => w.Value));
        }
    }

    public class UserData
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeID { get; set; }
        public DateTime LastUpdate { get; set; }

        public UserData() {
            this.UserID = -1;
            this.UserName = "";
            this.DisplayName = "";
            this.UserTypeID = "";
            this.UserTypeName = "";
            this.LastUpdate = DateTime.MinValue;
        }

        public void ClearData() {
            this.UserID = -1;
            this.UserName = "";
            this.DisplayName = "";
            this.UserTypeID = "";
            this.UserTypeName = "";
            this.LastUpdate = DateTime.MinValue;
        }
    }
}
