using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_blog_v1.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
