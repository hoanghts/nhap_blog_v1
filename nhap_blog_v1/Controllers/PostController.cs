﻿using System;
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
    public class PostController : ControllerBase
    {
        public IPostRepository _re;
        public PostController(IPostRepository re)
        {
            _re = re;
        }
        /// <summary>
        /// Them bai Post moi
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Admin, Superuser")]
        public async Task Add([FromBody] PostDto P)
        {
             await _re.Add(P);
        }

        /// <summary>
        /// Dem tong so Comment cua 1 bai Post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CountComment/{Id}")]
        public int CountComment(int Id)
        {
            return _re.CountComment(Id);
        }

        /// <summary>
        /// Xoa 1 Post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{Id}")]
        [Authorize(Roles = "Admin, Superuser")]
        public async Task Delete(int Id)
        {
            await _re.Delete(Id);
        }

        /// <summary>
        /// Lay ra 1 PostDto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<PostDto> Get(int Id)
        {
            return await _re.Get(Id);
        }

        /// <summary>
        /// Lay ra 1 PostFullDto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFull/{Id}")]
        public async Task<PostFullDto> GetFull(int Id)
        {
            return await _re.GetFull(Id);
        }

        /// <summary>
        /// Lay 1 post co Id lon hon Id hien tai
        /// </summary>
        /// <param name="CurrentPostID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("NextPost/{CurrentPostID}")]
        public async Task<PostFullDto> NextPost(int CurrentPostID)
        {
            return await _re.NextPost(CurrentPostID);
        }

        /// <summary>
        /// Lay 1 post co Id nho hon Id hien tai
        /// </summary>
        /// <param name="CurrentPostID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PreviousPost/{CurrentPostID}")]
        public async Task<PostFullDto> PreviousPost(int CurrentPostID)
        {
            return await _re.PreviousPost(CurrentPostID);
        }

        /// <summary>
        /// update 1 post
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{Id}")]
        [Authorize(Roles = "Admin, Superuser")]
        public async Task Update(int Id,[FromBody] PostDto P)
        {
            await _re.Update(Id, P);
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
        [Route("GetPostByPage/{Page}")]
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