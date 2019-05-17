using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_blog_v1.Dto;
using nhap_blog_v1.Repository;

namespace nhap_blog_v1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountRepository _re;
        public AccountController(IAccountRepository re)
        {
            _re = re;
        }

        /// <summary>
        /// Xoa account (Role admin)
        /// </summary>
        /// <param name="Id"></param>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{Id}")]
        public void Delete(int Id)
        {
            _re.Delete(Id);
        }

        /// <summary>
        /// dang nhap
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AccountDto user)
        {
            var result = _re.Login(user.UserName, user.PassWord);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        /// <summary>
        /// dang ki
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task register([FromBody] AccountDto user)
        {
             await _re.register(user);
        }

        /// <summary>
        /// update account (role admin)
        /// </summary>
        /// <param name="user"></param>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public void Update([FromBody] AccountDto user)
        {
            _re.Update(user);
        }
    }
}