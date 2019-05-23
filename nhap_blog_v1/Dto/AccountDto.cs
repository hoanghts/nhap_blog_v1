using nhap_blog_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_blog_v1.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Role Role { get; set; }
    }

    public class megReturn
    {
        public int errCode { get; set; }
        public string meg { get; set; }
        public string username { get; set; }
        public string Role { get; set; }
    }
    public class megReturnDto
    {
        public int errCode { get; set; }
        public string meg { get; set; }
    }
}
