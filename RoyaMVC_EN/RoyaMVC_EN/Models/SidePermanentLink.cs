using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models
{
    public class SidePermanentLink
    {
        public long IDWebLink { get; set; }
        public string WebLinkTitle { get; set; }
        public string WebLink { get; set; }
        public int WebLinkCategoryID { get; set; }
        public bool HasStoredThumbnailImage { get; set; }
        public byte[] ThumbnailImage { get; set; }
        public string ThumbnailImageAddress { get; set; }
        public bool IsRelativeThumbnailImageLink { get; set; }
    }
}
