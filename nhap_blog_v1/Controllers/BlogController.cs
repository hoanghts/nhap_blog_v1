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
        /// Dem so page Post
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CountPage")]
        public async Task<int> CountPage()
        {
            return await _re.CountPage();
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

        /// <summary>
        /// Lay List cac bai Post moi nhat (mac dinh lay toi da 5 bai)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("NewPost")]
        public async Task<List<PostDto>> GetNewPost()
        {
            return await _re.GetNewPost();
        }

        /// <summary>
        /// Lay so bai Post dua vao viec chon so trang
        /// </summary>
        /// <param name="Page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Page}")]
        public async Task<List<PostDto>> GetPostByPage(int Page)
        {
            return await _re.GetPostByPage(Page);
        }

        /// <summary>
        /// Nhay sang Page lon hon page hien tai
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("NextPage/{CurrentPage}")]
        public async Task<List<PostDto>> NextPage(int CurrentPage)
        {
            return await _re.NextPage(CurrentPage);
        }

        /// <summary>
        /// Nhay sang page nho hon page hien tai
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PreviousPage/{CurrentPage}")]
        public async Task<List<PostDto>> PreviousPage(int CurrentPage)
        {
            return await _re.PreviousPage(CurrentPage);
        }
    }
}