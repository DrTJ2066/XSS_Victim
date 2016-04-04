using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoyaMVC_EN.Repositories;
using RoyaMVC_EN.Models;
using System.Data.Entity.Core.Objects;

namespace RoyaMVC_EN.Models.Repositories
{
    public partial class GeneralRepository<ContextType> : RepositoryBase<ContextType>, IRepositoryBase<ContextType>  where ContextType : ObjectContext, IRoyaContext
    {
        public IWebsiteSettings WebSiteSettings;

        public event Action<IWebsiteSettings> OnLoad;

        public void Load() {
            this.WebSiteSettings = new WebSiteSettingsData();
            if (OnLoad != null) OnLoad(this.WebSiteSettings);
        }

    }
}
