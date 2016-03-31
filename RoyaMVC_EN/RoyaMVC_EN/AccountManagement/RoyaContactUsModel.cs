using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RoyaMVC_EN.AccountManagement
{
    public class RoyaContactUsModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string PersonFullName { get; set; }

        [Display(Name = "پست الکترونیک")]
        public string EMail { get; set; }

        [Display(Name = "وبسایت")]
        public string WebSite { get; set; }

        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "عنوان پیام")]
        public string MessageSubject { get; set; }

        [Display(Name = "پیغام")]
        public string MessageBody { get; set; }

        public long MessageID { get; set; }
        public bool IsRead { get; set; }
        public string MessageDateTime { get; set; }
        public DateTime MessageDateTimeGregorian { get; set; }

        public bool RememberMe { get; set; }
    }
}
