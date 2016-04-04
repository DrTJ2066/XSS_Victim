using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoyaMVC_EN.Models.Repositories;
using RoyaMVC_EN.Repositories;
using RoyaMVC_EN.Models;
using System.Data.Entity.Core.Objects;

namespace RoyaMVC_EN.Controllers
{
    public partial class CustomControllerBase<ControllerContextType> : Controller where ControllerContextType : ObjectContext, IRoyaContext
    {
        protected RoyaMVC_EN.Models.Repositories.GeneralRepository<ControllerContextType> repoGeneral = new GeneralRepository<ControllerContextType>();

        public CustomControllerBase()
            : base() {
            repoGeneral.OnLoad += w => { w = new WebSiteSettingsData(); };

            repoGeneral.Load();
            ViewBag.FooterText = repoGeneral.WebSiteSettings.FooterText ?? "";


            var sideText = repoGeneral.WebSiteSettings.SidePanelScriptsInnerHtml ?? "";
            if (!string.IsNullOrWhiteSpace(sideText)) {
                ViewBag.SidePanelHtml = string.Format("<div class='SidePanelTitleBar'><span>ابزار ها</span></div>{0}", sideText);
            }

            if (ViewBag.LogonData == null)
                ViewBag.LogonData = new RoyaMVC_EN.AccountManagement.LoginModel();

            ViewBag.TopLogoAlternativeText = repoGeneral.WebSiteSettings.TopLogoAlternativeText ?? "شرکت رویا پژوهش";
            ViewBag.TopLogoURL = repoGeneral.WebSiteSettings.TopLogoURL ?? "../Content/Images/Logo180.jpg";
            ViewBag.DesignerNote = repoGeneral.WebSiteSettings.DesignedByBottomText ?? "<div style='font-family:Tahoma; font-size:smaller;text-align:center;'><a href='http://www.RoyaPajoohesh.ir' style='text-decoration:none;'>طراحی و پیاده سازی توسط شرکت رویاپژوهش</a></div>";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            ViewBag.HasErrors = false;
            base.OnActionExecuting(filterContext);
        }


    }
}
