//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XSS_Victim.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int IDUser { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string RegisterationDateTime { get; set; }
        public System.DateTime RegisterationDateTimeGregorian { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
        public string WebAddress { get; set; }
        public long AddressCountryID { get; set; }
        public long AddressProvinceID { get; set; }
        public long AddressCityID { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public bool IsEmployee { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual webpages_Membership webpages_Membership { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
