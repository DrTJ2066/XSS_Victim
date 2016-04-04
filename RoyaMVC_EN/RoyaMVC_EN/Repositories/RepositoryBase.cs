using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Web;

namespace RoyaMVC_EN.Models.Repositories
{
    public partial class RepositoryBase<ContextType> : IRepositoryBase<ContextType> where ContextType : ObjectContext, IDisposable
    {
        public ContextType Context { get; set; }

        public RepositoryBase() {
            var ty = typeof(ContextType);
            var inf = ty.GetConstructor(new Type[] { });
            this.Context = (ContextType)inf.Invoke(null);
        }
        
        public byte[] UploadFile(HttpRequest request, string fileUploadID)
        {
            if (request.Files.AllKeys.Contains(fileUploadID)) {
                HttpPostedFile file = request.Files[fileUploadID];
                int fileLength = file.ContentLength;

                byte[] theContent = new byte[fileLength];
                file.InputStream.Read(theContent, 0, fileLength);

                return theContent;
            }
            else {
                return new byte[0];
            }

        }

        public static string Alert(string Message) {
            return string.Format("<script>alert('{0}');</script>", Message);
        }

        public void Dispose() {
            this.Context.Dispose();
        }
    }
}
