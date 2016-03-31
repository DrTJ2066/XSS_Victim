using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSS_Victim.Models.Repositories
{
    public interface IRepositoryBase<ContextType>
    {
        ContextType Context { get; set; }
    }
}
