﻿//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Processa"> 
// Copyright (c) 2016 Todos los derechos reservados.
// </copyright>
// <author>mtaghi</author>
// <date>3/30/2016 5:00:00 PM</date>
//-----------------------------------------------------------------------
namespace XSS_Victim.Controllers
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using XSS_Victim.Models.Repositories;
    #endregion

    public class HomeController : BaseController
    {
        private UsersRepository repoUser;

        public HomeController() : base()
        {
            this.repoUser = new UsersRepository();
        }

        public ActionResult Index()
        {
            var users = repoUser.GetUsersList();
            return View(users);
        }

        public ActionResult About() {
            return View();
        }
    }
}
