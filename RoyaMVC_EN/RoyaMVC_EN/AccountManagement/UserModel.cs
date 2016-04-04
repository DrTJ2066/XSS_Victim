using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoyaMVC_EN.Models
{
    public enum UserRoles { Admin = 1, User = 2, DemoAdmin = 3, DemoUser = 4 }

    [Table("Users")]
    public class Users
    {
        [Key]
        public int IDUser { get; set; }
        public long WebsiteID { get; set; }
        public int UserRoleID { get; set; }

        [Display(Name = "Full Name :")]
        public string UserFullName { get; set; }
        
        [Required]
        [Display(Name = "Username :")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "EMail :")]
        public string EMail { get; set; }

        [Display(Name = "Telephone :")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Mobile :")]
        public string Mobile { get; set; }

        [Display(Name = "Description :")]
        public string Description { get; set; }

        [Display(Name = "Country :")]
        public string AddressCountryName { get; set; }

        [Display(Name = "State/Province :")]
        public string AddressProvinceName { get; set; }

        [Display(Name = "City :")]
        public string AddressCityName { get; set; }

        [Display(Name = "Address Line 1 :")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2 :")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Profile Image :")]
        public string ProfileImagePath { get; set; }

        public string RegisterationDateTime { get; set; }
        public DateTime RegisterationDateTimeGregorian { get; set; }
        
        
    }
}