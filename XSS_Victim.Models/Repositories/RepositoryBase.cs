﻿//-----------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Processa"> 
// Copyright (c) 2016 Todos los derechos reservados.
// </copyright>
// <author>mtaghi</author>
// <date>3/30/2016 6:47:18 PM</date>
//-----------------------------------------------------------------------

using XSS_Victim.DAL;

namespace XSS_Victim.Models.Repositories
{
    #region using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class RepositoryBase
    {
        public SocialDataEntities Context = new SocialDataEntities();
    }
}
