using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models
{
    public partial class CompanyData: ICompanyData
    {
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }

        public CompanyData() {
            this.Phone1 = "";
            this.Phone2 = "";
            this.Fax = "";
            this.WebAddress = "";
            this.CompanyName = "";
            this.Address = "";
            this.AddressLatitude = "";
            this.AddressLongitude = "";

        }

        public CompanyData(ICompanyData original) {
            this.Phone1 = original.Phone1;
            this.Phone2 = original.Phone2;
            this.Fax = original.Fax;
            this.WebAddress = original.WebAddress;
            this.CompanyName = original.CompanyName;
            this.Address = original.Address;
            this.AddressLatitude = original.AddressLatitude;
            this.AddressLongitude = original.AddressLongitude;
        }
    }
}
