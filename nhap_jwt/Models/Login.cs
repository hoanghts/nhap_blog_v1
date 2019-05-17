using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_jwt.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public static class Role {
        public const string Admin = "Admin";
        public const string User = "User";
    }

}
