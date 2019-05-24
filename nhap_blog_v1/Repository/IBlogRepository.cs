using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;

namespace nhap_blog_v1.Repository
{
    public interface IBlogRepository
    {
        string GetName();
        List<PostDto> GetPosts();
    }
}
