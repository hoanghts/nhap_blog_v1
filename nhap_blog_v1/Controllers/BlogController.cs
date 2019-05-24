using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_blog_v1.Dto;
using nhap_blog_v1.Repository;

namespace nhap_blog_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public IBlogRepository _re;
        public BlogController(IBlogRepository re)
        {
            _re = re;
        }

        /// <summary>
        /// Lay ten cua Blog
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [Route("Name")]
        public string GetName()
        {
            return _re.GetName();
        }
        [HttpGet]
        [Route("allpost")]
        public List<PostDto> GetAllPost()
        {
            return _re.GetPosts();
        }
    }
}