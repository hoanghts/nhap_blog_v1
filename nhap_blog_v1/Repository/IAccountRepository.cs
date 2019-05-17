using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nhap_blog_v1.Dto;

namespace nhap_blog_v1.Repository
{
    public interface IAccountRepository
    {
        Task register(AccountDto user);
        string Login(string username, string password);
        void Update(AccountDto user);
        void Delete(int Id);
    }
}
