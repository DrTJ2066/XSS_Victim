using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XSS_Victim.Controllers
{
    public class HomeController : Controller
    {
        private XSS_Victim.Models.Repositories.PostsRepository repoPosts;

        public ActionResult Index()
        {
            ViewBag.PostItems = repoPosts.GetPosts();

            return View();
        }

        public ActionResult About() {
            return View();
        }
    }
}
