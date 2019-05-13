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
        Task<PostFullDto> Get(int Id);
        Task<PostFullDto> GetFull(int Id);
        Task Add(PostDto P);
        Task Update(int Id, PostDto P);
        Task Delete(int Id);
        Task<int> CountComment(int Id);
        Task<PostFullDto> NextPost(int Unit, int CurrentPage);
        Task<PostFullDto> PreviousPost(int Unit, int CurrentPage);
    }
}
