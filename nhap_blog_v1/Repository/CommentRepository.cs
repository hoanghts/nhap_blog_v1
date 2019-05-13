using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;
using AutoMapper;

namespace nhap_blog_v1.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public ClassDbContext _db;
        public IMapper _mp;
        public CommentRepository(ClassDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }
        public Task Add(CommentDto P)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountSubComment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentFullDto>> GetFullComment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int Id, CommentDto P)
        {
            throw new NotImplementedException();
        }
    }
}
