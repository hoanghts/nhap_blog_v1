using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_blog_v1.Repository
{
    public interface IUserRepository
    {
        int GetId(string Email);
    }
}
