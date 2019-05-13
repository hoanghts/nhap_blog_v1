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
        //int CountPage(int Unit);
        //Task<List<PostDto>> GetPostByPage(int Unit, int Page);
        Task<Dictionary<int,List<PostDto>>> GetPostByPage(int Unit, int Page);
        Task<List<PostDto>> NextPage(int Unit, int CurrentPage);
        Task<List<PostDto>> PreviousPage(int Unit, int CurrentPage);
    }
}
