using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_blog_v1.Dto;
using nhap_blog_v1.Repository;

namespace nhap_blog_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public ICommentRepository _re;
        public CommentController(ICommentRepository re)
        {
            _re = re;
        }

        /// <summary>
        /// Them moi comment
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task Add(CommentDto P)
        {
            await _re.Add(P);
        }

        /// <summary>
        /// Dem so SubComment cua 1 Comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CountSubComment/{Id}")]
        public async Task<int> CountSubComment(int Id)
        {
            return await _re.CountSubComment(Id);
        }

        /// <summary>
        /// Delete 1 Comment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{Id}")]
        public async Task Delete(int Id)
        {
            await _re.Delete(Id);
        }

        /// <summary>
        /// Lay 1 CommentDto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<CommentDto> Get(int Id)
        {
            return await _re.Get(Id);
        }

        /// <summary>
        /// Lay 1 CommentFullDto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFullComment/{Id}")]
        public async Task<List<CommentFullDto>> GetFullComment(int Id)
        {
            return await _re.GetFullComment(Id);
        }

        /// <summary>
        /// update 1 Comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{Id}")]
        public async Task Update(int Id, CommentDto P)
        {
            await _re.Update(Id, P);
        }
    }
}