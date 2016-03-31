using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Repositories
{
    public interface IWebsiteSettings
    {
        string DesignedByBottomText { get; set; }
        string TopLogoURL { get; set; }
        string TopLogoAlternativeText { get; set; }
        string SidePanelScriptsInnerHtml { get; set; }
        string FooterText { get; set; }
    }
}
