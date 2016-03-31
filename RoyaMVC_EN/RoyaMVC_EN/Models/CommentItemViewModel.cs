using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models
{
    public class CommentItemViewModel
    {
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string CommentBody { get; set; }
        public RoyaDateEngine.SimpleDateTime CommentDateTime { get; set; }
    }
}
