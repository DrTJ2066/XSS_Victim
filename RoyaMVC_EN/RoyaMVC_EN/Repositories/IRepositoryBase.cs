using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RoyaMVC_EN.Models.Repositories
{
    public interface IRepositoryBase<ContextType>
    {
        ContextType Context { get; set; }

        byte[] UploadFile(HttpRequest request, string fileUploadID);

    }

}
