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
        Task<List<PostDto>> GetNewPost();
        Task<int> CountPage();
        Task<List<PostDto>> GetPostByPage(int Page);
        Task<List<PostDto>> NextPage(int CurrentPage);
        Task<List<PostDto>> PreviousPage(int CurrentPage);
    }
}
