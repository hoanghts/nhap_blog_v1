using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_blog_v1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<Comment> SubComment { get; set; }
    }
}
