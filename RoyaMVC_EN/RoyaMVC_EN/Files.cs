using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN
{
    public class UploadFileData
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] Content { get; set; }

        public static UploadFileData NoFile = new UploadFileData() { FileName = "nofile", Content = new byte[0], MimeType = "unknown/unknown" };
    }
}
