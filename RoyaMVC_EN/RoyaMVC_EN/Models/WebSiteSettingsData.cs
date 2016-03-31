using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoyaMVC_EN.Repositories;

namespace RoyaMVC_EN.Models
{
    public partial class WebSiteSettingsData : IWebsiteSettings 
    {
        public string FooterText { get; set; }
        public string AboutPage { get; set; }
        public string ContactUsBody { get; set; }
        public string SeminarsPageHeaderText { get; set; }

        public string SidePanelScriptsInnerHtml { get; set; }

        public ICompanyData CompanyData { get; set; }

        public string DesignedByBottomText { get; set; }
        public string TopLogoURL { get; set; }
        public string TopLogoAlternativeText { get; set; }


        public WebSiteSettingsData(WebSiteSettingsData original) {
            this.FooterText = original.FooterText;
            this.AboutPage = original.AboutPage;
            this.ContactUsBody = original.ContactUsBody;
            this.SeminarsPageHeaderText = original.SeminarsPageHeaderText;

            this.SidePanelScriptsInnerHtml = original.SidePanelScriptsInnerHtml;

            this.CompanyData = new CompanyData(original.CompanyData);

            this.DesignedByBottomText = original.DesignedByBottomText;
            this.TopLogoURL = original.TopLogoURL;
            this.TopLogoAlternativeText = original.TopLogoAlternativeText;
        }

        public WebSiteSettingsData() {
            this.FooterText = "";
            this.AboutPage = "";
            this.ContactUsBody = "";
            this.SeminarsPageHeaderText = "";

            this.SidePanelScriptsInnerHtml = "";

            this.CompanyData = new CompanyData();

            this.DesignedByBottomText = "";
            this.TopLogoURL = "";
            this.TopLogoAlternativeText = "";
        }
    }

}
