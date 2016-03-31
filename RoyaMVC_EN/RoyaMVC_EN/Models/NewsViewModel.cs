using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoyaMVC_EN.Models;

namespace RoyaMVC_EN.Repositories
{
    public interface INews
    {
        long NewsID { get; set; }
        int NewsCategoryID { get; set; }
        string NewsTypeTitle { get; set; }
        string Headline { get; set; }
        string Content { get; set; }
        bool IsPublished { get; set; }
        string PublishDate { get; set; }
        string PublishTime { get; set; }
        string Author { get; set; }
        bool IsSpecialNew { get; set; }
        string NewsShortDescription { get; set; }
        List<TagViewModel> Tags { get; set; }
    }

    public partial class NewsViewModel : INews
    {
        public long NewsID { get; set; }
        public int NewsCategoryID { get; set; }
        public string NewsTypeTitle { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public string PublishDate { get; set; }
        public string PublishTime { get; set; }
        public string Author { get; set; }
        public bool IsSpecialNew { get; set; }
        public string NewsShortDescription { get; set; }
        public List<TagViewModel> Tags { get; set; }

    }
}
