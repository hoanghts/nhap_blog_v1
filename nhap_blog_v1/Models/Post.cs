using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_blog_v1.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
