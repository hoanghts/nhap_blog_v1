using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;

namespace nhap_blog_v1.Repository
{
    public interface ICommentRepository
    {
        Task<CommentDto> Get(int Id);
        Task Add(CommentDto P);
        Task Update(int Id, CommentDto P);
        Task Delete(int Id);
        Task<List<CommentFullDto>> GetFullComment(int Id);
        Task<int> CountSubComment(int Id);
    }
}
