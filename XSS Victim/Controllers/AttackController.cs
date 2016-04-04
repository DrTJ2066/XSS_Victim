﻿//-----------------------------------------------------------------------
// <copyright file="AttackController.cs" company="Processa"> 
// Copyright (c) 2016 Todos los derechos reservados.
// </copyright>
// <author>mtaghi</author>
// <date>3/31/2016 9:30:00 AM</date>
//-----------------------------------------------------------------------
namespace XSS_Victim.Controllers
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    #endregion

    public class AttackController : BaseController
    {
        //
        // GET: /Attack/

        public ActionResult Index()
        {
            return View();
        }

    }
}
