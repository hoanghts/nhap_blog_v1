using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace nhap_blog_v1.Repository
{
    public class BlogRepository : IBlogRepository
    {
        public ClassDbContext _db;
        public IMapper _mp;
        public BlogRepository(ClassDbContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }
        /// <summary>
        /// Dua theo tham so Chia (Unit). Dem so page Post
        /// </summary>
        /// <param name="Unit"></param>
        /// <returns></returns>
        public int CountPage(int Unit)
        {
            int re = 0;
            int countpost =  _db.Posts.Count();
            if (countpost < 1) re = 0;
            re = countpost / Unit;
            return re;
        }

        /// <summary>
        /// Lay ten cua Blog
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return _db.Blogs.Single().Name;
        }
        
        /// <summary>
        /// Lay List cac bai Post moi nhat (mac dinh lay toi da 5 bai)
        /// </summary>
        /// <returns></returns>
        public async Task<List<PostDto>> GetNewPost()
        {
            var re = await _db.Posts.ToListAsync();
            var kq = re.OrderByDescending(x => x.DateCreated).Take(5).ToList();
            return _mp.Map<List<PostDto>>(kq);
        }

        /// <summary>
        /// Lay so bai Post dua vao viec chon so trang
        /// </summary>
        /// <param name="Unit"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        public async Task<Dictionary<int,List<PostDto>>> GetPostByPage(int Unit, int Page)
        {
            Dictionary<int, List<PostDto>> result = new Dictionary<int, List<PostDto>>();
            int count = CountPage(Unit);
            if (count >= Page)
            {
                var buf = await _db.Posts.ToListAsync();
                List<PostDto> listPost = _mp.Map<List<PostDto>>(buf.OrderByDescending(x => x.DateCreated).Skip(Unit * Page).ToList());
                result.Add(count, listPost);
            }
            else result.Add(count, null);
            return result;
        }

        public Task<List<PostDto>> NextPage(int Unit, int CurrentPage)
        {
            
        }

        public Task<List<PostDto>> PreviousPage(int Unit, int CurrentPage)
        {
            throw new NotImplementedException();
        }
    }
}
