using System;

namespace XSS_Victim.Models
{
    public class PostModel
    {
        public string Author { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string PostContent { get; set; }
    }
}