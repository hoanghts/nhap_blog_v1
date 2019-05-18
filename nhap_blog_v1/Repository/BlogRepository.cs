using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EasyCaching.Core;
using nhap_blog_v1.Log;

namespace nhap_blog_v1.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IEasyCachingProvider _pro;
        public ClassDbContext _db;
        public IMapper _mp;
        private ILog _logger;
        public BlogRepository(ClassDbContext db, IMapper mp, IEasyCachingProvider provider, ILog logg)
        {
            _db = db;
            _mp = mp;
            _pro = provider;
            _logger = logg;
        }
        /// <summary>
        /// Lay ten cua Blog
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            _logger.Information("Information is logged");
            _logger.Warning("Warning is logged");
            _logger.Debug("Debug log is logged");
            _logger.Error("Error is logged");

            var buf = _pro.Get<string>("getname");
            if (!buf.IsNull) return buf.ToString();
            var buf1 = _db.Blogs.Single().Name;
            _pro.Set<string>("getname", buf1, TimeSpan.FromDays(1));
            return buf1;
        }
    }
}
