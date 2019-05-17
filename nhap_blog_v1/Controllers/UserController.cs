using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_blog_v1.Repository;

namespace nhap_blog_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository _re;
        public UserController(IUserRepository re)
        {
            _re = re;
        }

        [HttpGet]
        [Route("{Email}")]
        public int GetId(string Email)
        {
            return _re.GetId(Email);
        }
    }
}