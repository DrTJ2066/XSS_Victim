using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models
{
    public class CommentItemViewModel
    {
        public string FullName { get; set; }
        public int RelatedUserId { get; set; }
        public string WebAddress { get; set; }
        public string Email { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}
