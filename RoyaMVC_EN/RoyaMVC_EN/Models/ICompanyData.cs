using System;
namespace RoyaMVC_EN.Models
{
    public interface ICompanyData
    {
        string Phone1 { get; set; }
        string Phone2 { get; set; }
        string Fax { get; set; }
        string WebAddress { get; set; }
        string CompanyName { get; set; }
        string Address { get; set; }
        string AddressLatitude { get; set; }
        string AddressLongitude { get; set; }
    }
}
