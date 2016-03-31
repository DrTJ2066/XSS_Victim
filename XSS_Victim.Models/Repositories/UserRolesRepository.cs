using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSS_Victim.Models.Repositories
{
    public class UserRolesRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        public UserRolesRepository() : base() { }
    }
}
