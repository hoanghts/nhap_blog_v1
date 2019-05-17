using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using nhap_blog_v1.Dto;
using nhap_blog_v1.Models;

namespace nhap_blog_v1.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public IConfiguration Configuration { get; }
        public IMapper _mp;
        public ClassDbContext _db;
        public AccountRepository(ClassDbContext db, IMapper mp, IConfiguration _Configuration)
        {
            _db = db;
            _mp = mp;
            Configuration = _Configuration;
        }
        public void Delete(int Id)
        {
            var user = _db.Accounts.Find(Id);
            if (user != null)
            {
                _db.Accounts.Remove(user);
                _db.SaveChanges();
            }
            
        }

        public string Login(string username, string password)
        {
            string result = null;
            var login = _db.Accounts.Where(u => u.UserName == username && u.PassWord == password).FirstOrDefault();
            if (login != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["jwt:SecurityKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(ClaimTypes.Role, login.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                result = tokenHandler.WriteToken(token);
            }
            return result;
        }

        public async Task register(AccountDto user)
        {
            if (user != null)   
            {
                var buf = _mp.Map<Account>(user);
                await _db.Accounts.AddAsync(buf);
                await _db.SaveChangesAsync();
            }
        }

        public void Update(AccountDto user)
        {
            var ac = _db.Accounts.Find(user.Id);
            var buf = _mp.Map<Account>(ac);
            ac.Id = buf.Id;
            ac.UserName = buf.UserName;
            ac.PassWord = buf.PassWord;
            ac.Role = buf.Role;
            _db.SaveChanges();
        }
    }
}
