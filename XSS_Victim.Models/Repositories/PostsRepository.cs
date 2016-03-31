﻿//-----------------------------------------------------------------------
// <copyright file="PostsRepository.cs" company="Processa"> 
// Copyright (c) 2016 Todos los derechos reservados.
// </copyright>
// <author>mtaghi</author>
// <date>3/30/2016 6:02:21 PM</date>
//-----------------------------------------------------------------------
namespace XSS_Victim.Models.Repositories
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// Representa la información del objeto PostsRepository.
    /// </summary>
    public class PostsRepository : RepositoryBase
    {
        public PostsRepository() : base() { }

        public List<DAL.Posts> GetPosts(int count = 0)
        {
            if (count == 0)
            {
                return this.Context.Posts.ToList();
            }

            var itemsCount = this.Context.Posts.Count();
            count = itemsCount >= count ? count : itemsCount;

            return this.Context.Posts.Take(count).ToList();
        }
    }
}