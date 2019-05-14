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
        public async Task Add(CommentDto P)
        {
            var buf = _mp.Map<Comment>(P);
            await _db.Comments.AddAsync(buf);
            await _db.SaveChangesAsync();
        }

        public async Task<int> CountSubComment(int Id)
        {
            int result = 0;
            var re = _db.Comments.Where(x => x.ParentId == Id).ToList();
            result = result + re.Count;
            foreach (var item in re)
            {
                int countBuf = 0;
                List<Comment> listBuf = new List<Comment>() { item };
                while (countBuf < listBuf.Count)
                {
                    Comment cmBuf = listBuf[countBuf];
                    var reBuf = _db.Comments.Where(x => x.ParentId == cmBuf.Id).ToList();
                    result = result + reBuf.Count;
                    listBuf.AddRange(reBuf);
                    countBuf++;
                }
            }
            return result;
        }
    

        public async Task Delete(int Id)
        {
            var re = _db.Comments.Where(x => x.ParentId == Id).ToList();
            if (re.Count > 0)
            {
                foreach (var item in re)
                {
                    int countBuf = 0;
                    List<Comment> listBuf = new List<Comment>() { item };
                    while (countBuf < listBuf.Count)
                    {
                        Comment cmBuf = listBuf[countBuf];
                        var reBuf = _db.Comments.Where(x => x.ParentId == cmBuf.Id).ToList();

                        listBuf.AddRange(reBuf);
                        _db.Comments.Remove(cmBuf);
                        countBuf++;
                    }
                }
                var comment = _db.Comments.Find(Id);
                _db.Comments.Remove(comment);
                _db.SaveChanges();
            }
        }

        public async Task<CommentDto> Get(int Id)
        {
            return _mp.Map<CommentDto>(await _db.Comments.FindAsync(Id));
        }

        public async Task<List<CommentFullDto>> GetFullComment(int Id)
        {
            List<CommentFullDto> result = new List<CommentFullDto>();
            var re = _mp.Map<List<CommentFullDto>>(_db.Comments.Where(x => x.ParentId == Id).ToList());
            foreach (CommentFullDto item in re)
            {
                List<CommentFullDto> buf = new List<CommentFullDto> { item };
                List<CommentFullDto> result_1 = new List<CommentFullDto>();
                int count = 0;
                while (count < buf.Count)
                {
                    CommentFullDto bufCm = buf[count];
                    var re_1 = _mp.Map<List<CommentFullDto>>(_db.Comments.Where(x => x.ParentId == bufCm.Id).ToList());
                    if (re_1.Count() > 0)
                    {
                        buf.AddRange(re_1);
                        result_1[count].SubComment = re_1;
                        result_1.AddRange(result_1[count].SubComment);
                    }
                    count++;
                }
                result.Add(result_1[0]);
            }
            return result;
        }

        public async Task Update(int Id, CommentDto P)
        {
            var re = await _db.Comments.FindAsync(Id);
            var buf = _mp.Map<Comment>(P);
            re = buf;
            await _db.SaveChangesAsync();
        }
    }
}
