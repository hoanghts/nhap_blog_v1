using System;
using System.Collections.Generic;
using nhap_blog_v1.Models;

namespace nhap_blog_v1.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class PostFullDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<CommentDto> Comments { get; set; }
    }
}
