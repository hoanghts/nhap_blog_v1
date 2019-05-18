using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;

namespace nhap_blog_v1.Repository
{
    public interface IPostRepository
    {
        Task<PostDto> Get(int Id);
        Task<PostFullDto> GetFull(int Id);
        Task Add(PostDto P);
        Task Update(int Id, PostDto P);
        Task Delete(int Id);
        int CountComment(int Id);
        Task<PostFullDto> NextPost(int CurrentPostID);
        Task<PostFullDto> PreviousPost(int CurrentPostID);
        Task<List<PostDto>> GetNewPost();
        Task<int> CountPage();
        Task<List<PostDto>> GetPostByPage(int Page);
        Task<List<PostDto>> NextPage(int CurrentPage);
        Task<List<PostDto>> PreviousPage(int CurrentPage);
    }
}
