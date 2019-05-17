using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EasyCaching.Core;

namespace nhap_blog_v1.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IEasyCachingProvider _pro;
        public ClassDbContext _db;
        public IMapper _mp;
        public BlogRepository(ClassDbContext db, IMapper mp, IEasyCachingProvider provider)
        {
            _db = db;
            _mp = mp;
            _pro = provider;
        }
        /// <summary>
        /// Dem so page Post
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountPage()
        {
            int re = 1;
            int countpost = _db.Posts.Count();
            if (countpost < 1) re = 0;
            else re = countpost / 10 + 1;
            return re;
        }

        /// <summary>
        /// Lay ten cua Blog
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            var buf = _pro.Get<string>("getname");
            if (!buf.IsNull) return buf.ToString();
            var buf1 = _db.Blogs.Single().Name;
            _pro.Set<string>("getname", buf1, TimeSpan.FromSeconds(10));
            return buf1;
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
        /// <param name="Page"></param>
        /// <returns></returns>
        public async Task<List<PostDto>> GetPostByPage(int Page)
        {
            List<PostDto> result = new List<PostDto>();
            var buf = await _db.Posts.ToListAsync();
            result = _mp.Map<List<PostDto>>(buf.OrderByDescending(x => x.DateCreated).Skip(10 * (Page - 1)).Take(10).ToList());
            return result;
        }

        /// <summary>
        /// Nhay sang Page lon hon page hien tai
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        public async Task<List<PostDto>> NextPage(int CurrentPage)
        {
            List<PostDto> result = new List<PostDto>();
            int count = await CountPage();
            if (count > 1 && CurrentPage < count) result = await GetPostByPage(CurrentPage + 1);
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Nhay sang page nho hon page hien tai
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        public async Task<List<PostDto>> PreviousPage(int CurrentPage)
        {
            List<PostDto> result = new List<PostDto>();
            int count = await CountPage();
            if (count > 1 && CurrentPage > 1) result = await GetPostByPage(CurrentPage -1);
            else
            {
                result = null;
            }
            return result;
        }
    }
}
