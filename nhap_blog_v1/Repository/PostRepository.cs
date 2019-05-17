using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;
using AutoMapper;
using EasyCaching.Core;

namespace nhap_blog_v1.Repository
{
    /// <summary>
    /// class PostRepository
    /// </summary>
    public class PostRepository : IPostRepository
    {
        private readonly IEasyCachingProvider _pro;
        /// <summary>
        /// Field ClassDbcontext
        /// </summary>
        public ClassDbContext _db;
        /// <summary>
        /// Field Imapper
        /// </summary>
        public IMapper _mp;
        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mp"></param>
        public PostRepository(ClassDbContext db, IMapper mp, IEasyCachingProvider provider)
        {
            _db = db;
            _mp = mp;
            _pro = provider;
        }

        /// <summary>
        /// Them bai Post moi
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public async Task Add(PostDto P)
        {
            var buf = _mp.Map<Post>(P);
            await _db.Posts.AddAsync(buf);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Dem tong so Comment cua 1 bai Post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int CountComment(int Id)
        {
            return _db.Comments.Where(x => x.PostId == Id).Count();
        }

        /// <summary>
        /// Xoa 1 Post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task Delete(int Id)
        {
            var buf = await _db.Posts.FindAsync(Id);
            var bufCm = _db.Comments.Where(x => x.PostId == Id).ToList();
            _db.Posts.Remove(buf);
            bufCm.RemoveAll(x => x.PostId == Id);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Lay ra 1 PostDto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PostDto> Get(int Id)
        {
            var buf = await _pro.GetAsync<PostDto>("getPostDto");
            if (!buf.IsNull)
            {
                return buf.Value;
            }
            var result = _mp.Map<PostDto>(await _db.Posts.FindAsync(Id));
            if (result != null)
            {
                await _pro.SetAsync<PostDto>("getPostDto", result, TimeSpan.FromSeconds(10));
            }
            return result;
        }

        /// <summary>
        /// Lay ra 1 PostFullDto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PostFullDto> GetFull(int Id)
        {
            PostFullDto result = new PostFullDto();
            var buf = _mp.Map<PostFullDto>(await _db.Posts.FindAsync(Id));
            var cm = _db.Comments.Where(x => x.PostId == Id).Where(c => c.ParentId == null).ToList();
            result = buf;
            result.Comments = _mp.Map<List<CommentDto>>(cm);
            return result;
        }

        /// <summary>
        /// Lay 1 post co Id lon hon Id hien tai
        /// </summary>
        /// <param name="CurrentPostID"></param>
        /// <returns></returns>
        public async Task<PostFullDto> NextPost(int CurrentPostID)
        {
            PostFullDto result = new PostFullDto();
            int id = 0;
            var post = _db.Posts.Where(x => x.Id > CurrentPostID).FirstOrDefault();
            if (post == null)
            {
                id = CurrentPostID;
                result = null;
            }
            else
            {
                id = post.Id;
                result = await GetFull(id);
            }
            return result;
        }

        /// <summary>
        /// Lay 1 post co Id nho hon Id hien tai
        /// </summary>
        /// <param name="CurrentPostID"></param>
        /// <returns></returns>
        public async Task<PostFullDto> PreviousPost(int CurrentPostID)
        {
            var post = _db.Posts.Where(x => x.Id < CurrentPostID).FirstOrDefault();
            return await GetFull(post.Id);
        }

        /// <summary>
        /// update 1 post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="P"></param>
        /// <returns></returns>
        public async Task Update(int Id, PostDto P)
        {
            var re = await _db.Posts.FindAsync(Id);
            var buf = _mp.Map<Post>(P);
            re.Id = buf.Id;
            re.Title = buf.Title;
            re.Content = buf.Content;
            re.DateCreated = buf.DateCreated;
            re.Comments = re.Comments;
            await _db.SaveChangesAsync();
        }
    }
}
