using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;
using AutoMapper;

namespace nhap_blog_v1.Repository
{
    public class PostRepository : IPostRepository
    {
        public ClassDbContext _db;
        public IMapper _mp;
        public PostRepository(ClassDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }
        public Task Add(PostDto P)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountComment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostFullDto> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostFullDto> GetFull(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostFullDto> NextPost(int Unit, int CurrentPage)
        {
            throw new NotImplementedException();
        }

        public Task<PostFullDto> PreviousPost(int Unit, int CurrentPage)
        {
            throw new NotImplementedException();
        }

        public Task Update(int Id, PostDto P)
        {
            throw new NotImplementedException();
        }
    }
}
