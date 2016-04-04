﻿//-----------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="Processa"> 
// Copyright (c) 2016 Todos los derechos reservados.
// </copyright>
// <author>mtaghi</author>
// <date>3/31/2016 9:44:00 AM</date>
//-----------------------------------------------------------------------

using XSS_Victim.Models.Repositories;

namespace XSS_Victim.Controllers
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    #endregion

    public class ProfileController : BaseController
    {
        private PostsRepository repoPosts;
        private UsersRepository repoUsers;

        public ProfileController() : base()
        {
            this.repoPosts = new PostsRepository();
            this.repoUsers = new UsersRepository();
        }

        public ActionResult Index(int id)
        {
            ViewBag.PostItems = this.repoPosts.GetPosts(id);
            //var user = this.repoUsers.GetUser(id);
            var user = new DAL.Users()
            {
                BirthDate = DateTime.Now.Subtract(TimeSpan.FromDays(28 * 365)),
                UserFullName = "Mohammad Taghi Jahed",
                AddressCityName = "Bogota",
                AddressCountryName = "Colombia",
                Mobile = "3044337163",
                EMail = "mohammad.taghi@processa.com",
                ProfilePicturePath = "../../Content/UserContents/User999_ProfilePicture.png"
            };

            ViewBag.UserProfile = user;

            return View(user);
        }

    }
}
