using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_blog_v1.Models;

namespace nhap_blog_v1.Repository
{
    public class UserRepository : IUserRepository
    {
        public ClassDbContext _db;
        public UserRepository(ClassDbContext db)
        {
            _db = db;
        }
        public int GetId(string Email)
        {
            int result = 0;
            if (Email != null)
            {
                Email = Email.ToLower();
                var em = _db.Users.Where(x => x.Email == Email).FirstOrDefault();
                if (em != null)
                {
                    result = em.Id;
                }
                else
                {
                    var ad = new User() { Id = 0, Email = Email };
                    _db.Add(ad);
                    _db.SaveChanges();
                    var em_1 = _db.Users.Where(x => x.Email == Email).FirstOrDefault();
                    result = em_1.Id;
                }
            }
            return result;
        }
    }
}
